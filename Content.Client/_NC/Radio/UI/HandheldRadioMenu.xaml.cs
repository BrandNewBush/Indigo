using Content.Client.UserInterface.Controls;
using Content.Shared._NC.Radio;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client._NC.Radio.UI;
// TODO: Fix silly ui update issues
[GenerateTypedNameReferences]
public sealed partial class HandheldRadioMenu : UIKWindow
{

    public event Action<bool>? OnMicPressed;
    public event Action<bool>? OnSpeakerPressed;
    public event Action<string>? OnFrequencyChanged;

    private string _lastFrequency = "1330";

    public HandheldRadioMenu()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        MicButton.OnPressed += args => OnMicPressed?.Invoke(args.Button.Pressed);
        SpeakerButton.OnPressed += args => OnSpeakerPressed?.Invoke(args.Button.Pressed);

        FrequencyLineEdit.OnTextEntered += e => OnFrequencyChanged?.Invoke(e.Text);
        FrequencyLineEdit.OnTextChanged += ValidateText;
        FrequencyLineEdit.OnFocusExit += e => OnFrequencyChanged?.Invoke(e.Text);
    }

    private void ValidateText(LineEdit.LineEditEventArgs args)
    {
        if (!int.TryParse(args.Text, out int frequency))
        {
            FrequencyLineEdit.SetText(_lastFrequency);
            return;
        }

        _lastFrequency = args.Text;
    }

    public void Update(HandheldRadioBoundUIState state)
    {
        if (state.MicEnabled != MicButton.Pressed)
            MicButton.Pressed = state.MicEnabled;

        if (state.SpeakerEnabled != SpeakerButton.Pressed)
            SpeakerButton.Pressed = state.SpeakerEnabled;

        if (state.Frequency.ToString() != FrequencyLineEdit.Text)
            FrequencyLineEdit.Text = state.Frequency.ToString();
    }
}
