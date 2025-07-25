using Content.Shared.UIKit;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Options.UI;


[GenerateTypedNameReferences]
public sealed partial class OptionsMenu : UIKWindow
{
    public OptionsMenu()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        Tabs.AddTab(MiscTab, Loc.GetString("ui-options-tab-misc"), SymbolIcons.Settings, iconFilled: true);
        Tabs.AddTab(GraphicsTab, Loc.GetString("ui-options-tab-graphics"), SymbolIcons.Monitor, iconFilled: false);
        Tabs.AddTab(KeyRebindTab, Loc.GetString("ui-options-tab-controls"), SymbolIcons.Keyboard, iconFilled: true);
        Tabs.AddTab(AudioTab, Loc.GetString("ui-options-tab-audio"), SymbolIcons.Headphones, iconFilled: true);
        Tabs.AddTab(NetworkTab, Loc.GetString("ui-options-tab-network"), SymbolIcons.Lan, iconFilled: true);

        UpdateTabs();
    }

    public void UpdateTabs() => GraphicsTab.UpdateProperties();
}
