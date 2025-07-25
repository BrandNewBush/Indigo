using System.Linq;
using Content.Client.Atmos.EntitySystems;
using Content.Client.UserInterface.Controls;
using Content.Shared.Atmos.Prototypes;
using JetBrains.Annotations;
using Robust.Client.AutoGenerated;
using Robust.Client.Console;
using Robust.Client.Player;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Map.Components;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Administration.UI.Tabs.AtmosTab
{
    [GenerateTypedNameReferences]
    [UsedImplicitly]
    public sealed partial class AddGasWindow : UIKWindow
    {
        private List<NetEntity>? _gridData;
        private IEnumerable<GasPrototype>? _gasData;

        protected override void EnteredTree()
        {
            // Fill out grids
            var entManager = IoCManager.Resolve<IEntityManager>();
            var playerManager = IoCManager.Resolve<IPlayerManager>();

            var gridQuery = entManager.AllEntityQueryEnumerator<MapGridComponent>();
            _gridData ??= new List<NetEntity>();
            _gridData.Clear();

            while (gridQuery.MoveNext(out var uid, out _))
            {
                _gridData.Add(entManager.GetNetEntity(uid));
                var player = playerManager.LocalEntity;
                var playerGrid = entManager.GetComponentOrNull<TransformComponent>(player)?.GridUid;
                GridOptions.AddItem($"{uid} {(playerGrid == uid ? " (Current)" : "")}");
            }

            GridOptions.OnItemSelected += eventArgs => GridOptions.SelectId(eventArgs.Id);

            // Fill out gases
            _gasData = entManager.System<AtmosphereSystem>().Gases;

            foreach (var gas in _gasData)
            {
                var gasName = Loc.GetString(gas.Name);
                GasOptions.AddItem($"{gasName} ({gas.ID})");
            }

            GasOptions.OnItemSelected += eventArgs => GasOptions.SelectId(eventArgs.Id);

            SubmitButton.OnPressed += SubmitButtonOnOnPressed;
        }

        private void SubmitButtonOnOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (_gridData == null || _gasData == null)
                return;

            var gridIndex = _gridData[GridOptions.SelectedId];

            var gasList = _gasData.ToList();
            var gasId = gasList[GasOptions.SelectedId].ID;
            IoCManager.Resolve<IClientConsoleHost>().ExecuteCommand(
                $"addgas {TileXSpin.Value} {TileYSpin.Value} {gridIndex} {gasId} {AmountSpin.Value}");
        }
    }
}
