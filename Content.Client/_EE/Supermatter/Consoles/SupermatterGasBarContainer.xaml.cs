using Robust.Client.AutoGenerated;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._EE.Supermatter.Consoles;

[GenerateTypedNameReferences]
public sealed partial class SupermatterGasBarContainer : BoxContainer
{
    private readonly IEntityManager _entManager;

    public SupermatterGasBarContainer()
    {
        RobustXamlLoader.Load(this);

        _entManager = IoCManager.Resolve<IEntityManager>();
    }

    public void UpdateEntry(string name, Color color, float value)
    {
        GasBar.Value = value;
        GasLabel.Text = Loc.GetString(name) + ":";
        GasBarLabel.Text = Loc.GetString("supermatter-console-window-label-gas-bar", ("gas", value.ToString("0.00")));

        // Check if null first to avoid repeatedly creating this.
        GasBar.ForegroundStyleBoxOverride ??= new StyleBoxFlat();
        GasBarBorder.PanelOverride ??= new StyleBoxFlat();

        var barOverride = (StyleBoxFlat)GasBar.ForegroundStyleBoxOverride;
        barOverride.BackgroundColor = color;

        var borderOverride = (StyleBoxFlat)GasBarBorder.PanelOverride;
        borderOverride.BackgroundColor = color;
    }
}
