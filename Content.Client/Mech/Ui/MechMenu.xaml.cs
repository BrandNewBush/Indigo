using Content.Client.UserInterface.Controls;
using Content.Client.UserInterface.Fragments;
using Content.Shared.Mech.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface.XAML;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Mech.Ui;

[GenerateTypedNameReferences]
public sealed partial class MechMenu : UIKWindow
{
    [Dependency] private readonly IEntityManager _ent = default!;

    private EntityUid _mech;

    public event Action<EntityUid>? OnRemoveButtonPressed;

    public MechMenu()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);
    }

    public void SetEntity(EntityUid uid)
    {
        MechView.SetEntity(uid);
        _mech = uid;
    }

    public void UpdateMechStats()
    {
        if (!_ent.TryGetComponent<MechComponent>(_mech, out var mechComp))
            return;

        var integrityPercent = mechComp.Integrity / mechComp.MaxIntegrity;
        IntegrityDisplayBar.Value = integrityPercent.Float();
        IntegrityDisplay.Text = Loc.GetString("mech-integrity-display", ("amount", (integrityPercent*100).Int()));

        if (mechComp.MaxEnergy != 0f)
        {
            var energyPercent = mechComp.Energy / mechComp.MaxEnergy;
            EnergyDisplayBar.Value = energyPercent.Float();
            EnergyDisplay.Text = Loc.GetString("mech-energy-display", ("amount", (energyPercent*100).Int()));
        }
        else
        {
            EnergyDisplayBar.Value = 0f;
            EnergyDisplay.Text = Loc.GetString("mech-energy-missing");
        }

        SlotDisplay.Text = Loc.GetString("mech-slot-display",
            ("amount", mechComp.MaxEquipmentAmount - mechComp.EquipmentContainer.ContainedEntities.Count));
    }

    public void UpdateEquipmentView()
    {
        if (!_ent.TryGetComponent<MechComponent>(_mech, out var mechComp))
            return;

        EquipmentControlContainer.Children.Clear();
        foreach (var ent in mechComp.EquipmentContainer.ContainedEntities)
        {
            if (!_ent.TryGetComponent<MetaDataComponent>(ent, out var metaData))
                continue;

            var uicomp = _ent.GetComponentOrNull<UIFragmentComponent>(ent);
            var ui = uicomp?.Ui?.GetUIFragmentRoot();

            var control = new MechEquipmentControl(ent, metaData.EntityName, ui);

            control.OnRemoveButtonPressed += () => OnRemoveButtonPressed?.Invoke(ent);

            EquipmentControlContainer.AddChild(control);
        }
    }
}

