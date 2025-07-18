using Content.Client.UserInterface.Controls;
using Content.Shared.Silicons.Laws.Components;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Silicons.Laws.Ui;

[GenerateTypedNameReferences]
public sealed partial class SiliconLawMenu : UIKWindow
{
    public SiliconLawMenu()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);
    }

    public void Update(EntityUid uid, SiliconLawBuiState state)
    {
        state.Laws.Sort();
        LawDisplayContainer.Children.Clear();

        foreach (var law in state.Laws)
        {
            var control = new LawDisplay(uid, law, state.RadioChannels);

            LawDisplayContainer.AddChild(control);
        }
    }
}
