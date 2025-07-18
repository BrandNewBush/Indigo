using Content.Shared.Frontier.Storage.Components;
using Content.Shared.Materials;
using Robust.Shared.Physics.Components;
using Robust.Shared.Timing;
using Content.Shared.Examine;   // Frontier
using Content.Shared.Hands.Components;
using Content.Shared.UIKit;
// Frontier
using Content.Shared.Verbs;               // Frontier
using Robust.Shared.Utility;              // Frontier

namespace Content.Shared.Frontier.Storage.EntitySystems;

/// <summary>
/// <see cref="MaterialReclaimerMagnetPickupComponent"/>
/// </summary>
public sealed class MaterialReclaimerMagnetPickupSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly SharedMaterialReclaimerSystem _storage = default!;

    private static readonly TimeSpan ScanDelay = TimeSpan.FromSeconds(1);

    private EntityQuery<PhysicsComponent> _physicsQuery;

    public override void Initialize()
    {
        base.Initialize();
        _physicsQuery = GetEntityQuery<PhysicsComponent>();
        SubscribeLocalEvent<MaterialReclaimerMagnetPickupComponent, MapInitEvent>(OnMagnetMapInit);
        SubscribeLocalEvent<MaterialReclaimerMagnetPickupComponent, EntityUnpausedEvent>(OnMagnetUnpaused);
        SubscribeLocalEvent<MaterialReclaimerMagnetPickupComponent, ExaminedEvent>(OnExamined);  // Frontier
        SubscribeLocalEvent<MaterialReclaimerMagnetPickupComponent, GetVerbsEvent<AlternativeVerb>>(AddToggleMagnetVerb);    // Frontier
    }

    private void OnMagnetUnpaused(EntityUid uid, MaterialReclaimerMagnetPickupComponent component, ref EntityUnpausedEvent args)
    {
        component.NextScan += args.PausedTime;
    }

    private void OnMagnetMapInit(EntityUid uid, MaterialReclaimerMagnetPickupComponent component, MapInitEvent args)
    {
        component.NextScan = _timing.CurTime + TimeSpan.FromSeconds(1); // Need to add 1 sec to fix a weird time bug with it that make it never start the magnet
    }

    // Frontier, used to add the magnet toggle to the context menu
    private void AddToggleMagnetVerb(EntityUid uid, MaterialReclaimerMagnetPickupComponent component, GetVerbsEvent<AlternativeVerb> args)
    {
        if (!HasComp<HandsComponent>(args.User)
            || !args.CanInteract
            || !args.CanAccess)
            return;

        AlternativeVerb verb = new()
        {
            Act = () =>
            {
                component.MagnetEnabled = !component.MagnetEnabled;
            },
            GlyphIcon = SymbolIcons.PowerSettingsNew,
            Text = Loc.GetString("magnet-pickup-component-toggle-verb"),
            Priority = 3
        };

        args.Verbs.Add(verb);
    }

    // Frontier, used to show the magnet state on examination
    private void OnExamined(EntityUid uid, MaterialReclaimerMagnetPickupComponent component, ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString("magnet-pickup-component-on-examine-main",
                        ("stateText", Loc.GetString(component.MagnetEnabled
                        ? "magnet-pickup-component-magnet-on"
                        : "magnet-pickup-component-magnet-off"))));
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);
        var query = EntityQueryEnumerator<MaterialReclaimerMagnetPickupComponent, MaterialReclaimerComponent, TransformComponent>();
        var currentTime = _timing.CurTime;

        while (query.MoveNext(out var uid, out var comp, out var storage, out var xform))
        {
            if (comp.NextScan < currentTime)
                continue;

            comp.NextScan += ScanDelay;

            // Frontier - magnet disabled
            if (!comp.MagnetEnabled)
                continue;

            var parentUid = xform.ParentUid;

            foreach (var near in _lookup.GetEntitiesInRange(uid, comp.Range, LookupFlags.Dynamic | LookupFlags.Sundries))
            {
                if (!_physicsQuery.TryGetComponent(near, out var physics) || physics.BodyStatus != BodyStatus.OnGround)
                    continue;

                if (near == parentUid)
                    continue;

                _storage.TryStartProcessItem(uid, near);
            }
        }
    }
}
