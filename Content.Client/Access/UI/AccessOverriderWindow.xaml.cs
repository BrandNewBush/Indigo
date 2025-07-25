using System.Linq;
using Content.Client.UserInterface.Controls;
using Content.Shared.Access;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using static Content.Shared.Access.Components.AccessOverriderComponent;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Access.UI
{
    [GenerateTypedNameReferences]
    public sealed partial class AccessOverriderWindow : UIKWindow
    {
        [Dependency] private readonly ILocalizationManager _localization = default!;
        private readonly Dictionary<string, Button> _accessButtons = new();

        public event Action<List<ProtoId<AccessLevelPrototype>>>? OnSubmit;

        public AccessOverriderWindow()
        {
            IoCManager.InjectDependencies(this);
            RobustXamlLoader.Load(this);
        }

        public void SetAccessLevels(IPrototypeManager protoManager, List<ProtoId<AccessLevelPrototype>> accessLevels)
        {
            _accessButtons.Clear();
            AccessLevelGrid.DisposeAllChildren();

            foreach (var access in accessLevels)
            {
                if (!protoManager.TryIndex(access, out var accessLevel))
                {
                    continue;
                }

                var newButton = new Button
                {
                    Text = accessLevel.GetAccessLevelName(),
                    ToggleMode = true,
                };

                AccessLevelGrid.AddChild(newButton);
                _accessButtons.Add(accessLevel.ID, newButton);
                newButton.OnPressed += _ =>
                {
                    OnSubmit?.Invoke(
                        // Iterate over the buttons dictionary, filter by `Pressed`, only get key from the key/value pair
                        _accessButtons.Where(x => x.Value.Pressed).Select(x => new ProtoId<AccessLevelPrototype>(x.Key)).ToList());
                };
            }
        }

        public void UpdateState(IPrototypeManager protoManager, AccessOverriderBoundUserInterfaceState state)
        {
            PrivilegedIdLabel.Text = state.PrivilegedIdName;
            PrivilegedIdButton.Text = state.IsPrivilegedIdPresent
                ? _localization.GetString("access-overrider-window-eject-button")
                : _localization.GetString("access-overrider-window-insert-button");

            TargetNameLabel.Text = state.TargetLabel;
            TargetNameLabel.FontColorOverride = state.TargetLabelColor;

            MissingPrivilegesLabel.Text = "";
            MissingPrivilegesLabel.FontColorOverride = Color.Yellow;

            MissingPrivilegesText.Text = "";
            MissingPrivilegesText.FontColorOverride = Color.Yellow;

            if (state.MissingPrivilegesList != null && state.MissingPrivilegesList.Any())
            {
                var missingPrivileges = new List<string>();

                foreach (string tag in state.MissingPrivilegesList)
                {
                    var privilege = _localization.GetString(protoManager.Index<AccessLevelPrototype>(tag)?.Name ?? "generic-unknown");
                    missingPrivileges.Add(privilege);
                }

                MissingPrivilegesLabel.Text = _localization.GetString("access-overrider-window-missing-privileges");
                MissingPrivilegesText.Text = string.Join(", ", missingPrivileges);
            }

            var interfaceEnabled = state.IsPrivilegedIdPresent && state.IsPrivilegedIdAuthorized;

            foreach (var (accessName, button) in _accessButtons)
            {
                button.Disabled = !interfaceEnabled;
                if (!interfaceEnabled)
                    return;

                button.Pressed = state.TargetAccessReaderIdAccessList?.Contains<ProtoId<AccessLevelPrototype>>(accessName) ?? false;
                button.Disabled = (!state.AllowedModifyAccessList?.Contains<ProtoId<AccessLevelPrototype>>(accessName)) ?? true;
            }
        }
    }
}
