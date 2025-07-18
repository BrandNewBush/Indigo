﻿using Content.Client.Stylesheets;
using Content.Client.UserInterface.Controls;
using Content.Shared.DeviceNetwork;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.NetworkConfigurator;

[GenerateTypedNameReferences]
public sealed partial class NetworkConfiguratorConfigurationMenu : UIKWindow
{
    public event Action<string>? OnRemoveAddress;

    public NetworkConfiguratorConfigurationMenu()
    {
        RobustXamlLoader.Load(this);

        Clear.StyleClasses.Add(StyleBase.ButtonOpenLeft);
        Clear.StyleClasses.Add(StyleNano.StyleClassButtonColorRed);
        DeviceList.OnRemoveAddress += args =>
        {
            OnRemoveAddress?.Invoke(args);
        };
    }

    public void UpdateState(DeviceListUserInterfaceState state)
    {
        DeviceList.UpdateState(state.DeviceList, false);

        Count.Text = Loc.GetString("network-configurator-ui-count-label", ("count", state.DeviceList.Count));
    }
}
