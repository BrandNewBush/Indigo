using Content.Client.UserInterface.Controls;
using Content.Shared.Localizations;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Administration.UI.Tabs.AdminTab
{
    [GenerateTypedNameReferences]
    public sealed partial class AdminShuttleWindow : UIKWindow
    {
        public AdminShuttleWindow()
        {
            RobustXamlLoader.Load(this);
            IoCManager.InjectDependencies(this);

            _callShuttleTime.OnTextChanged += CallShuttleTimeOnOnTextChanged;
        }

        private void CallShuttleTimeOnOnTextChanged(LineEdit.LineEditEventArgs obj)
        {
            var loc = IoCManager.Resolve<ILocalizationManager>();
            _callShuttleButton.Disabled = !TimeSpan.TryParseExact(obj.Text, ContentLocalizationManager.TimeSpanMinutesFormats, loc.DefaultCulture, out _);
            _callShuttleButton.Command = $"callshuttle {obj.Text}";
        }
    }
}
