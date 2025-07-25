using Content.Client.Stylesheets;
using Content.Shared.StatusIcon;
using Robust.Client.AutoGenerated;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using System.Numerics;
using System.Linq;
using Content.Client.UserInterface.Controls;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Access.UI
{
    [GenerateTypedNameReferences]
    public sealed partial class AgentIDCardWindow : UIKWindow
    {
        [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
        [Dependency] private readonly IEntitySystemManager _entitySystem = default!;
        private readonly SpriteSystem _spriteSystem;

        private const int JobIconColumnCount = 10;

        private const int MaxNumberLength = 4; // DeltaV - Same as NewChatPopup

        public event Action<string>? OnNameChanged;
        public event Action<string>? OnJobChanged;

        public event Action<uint>? OnNumberChanged; // DeltaV - Add event for number changes

        public event Action<ProtoId<JobIconPrototype>>? OnJobIconChanged;

        public AgentIDCardWindow()
        {
            RobustXamlLoader.Load(this);
            IoCManager.InjectDependencies(this);
            _spriteSystem = _entitySystem.GetEntitySystem<SpriteSystem>();

            NameLineEdit.OnTextEntered += e => OnNameChanged?.Invoke(e.Text);
            NameLineEdit.OnFocusExit += e => OnNameChanged?.Invoke(e.Text);

            JobLineEdit.OnTextEntered += e => OnJobChanged?.Invoke(e.Text);
            JobLineEdit.OnFocusExit += e => OnJobChanged?.Invoke(e.Text);

            // DeltaV - Add handlers for number changes
            NumberLineEdit.OnTextEntered += OnNumberEntered;
            NumberLineEdit.OnFocusExit += OnNumberEntered;

            // DeltaV - Filter to only allow digits
            NumberLineEdit.OnTextChanged += args =>
            {
                if (args.Text.Length > MaxNumberLength)
                {
                    NumberLineEdit.Text = args.Text[..MaxNumberLength];
                }

                // Filter to digits only
                var newText = string.Concat(args.Text.Where(char.IsDigit));
                if (newText != args.Text)
                    NumberLineEdit.Text = newText;
            };
        }

        // DeltaV - Add number validation and event
        private void OnNumberEntered(LineEdit.LineEditEventArgs args)
        {
            if (uint.TryParse(args.Text, out var number) && number > 0)
                OnNumberChanged?.Invoke(number);
        }

        // DeltaV - Add setter for current number
        public void SetCurrentNumber(uint? number)
        {
            NumberLineEdit.Text = number?.ToString("D4") ?? "";
        }

        public void SetAllowedIcons(string currentJobIconId)
        {
            IconGrid.DisposeAllChildren();

            var jobIconButtonGroup = new ButtonGroup();
            var i = 0;
            var icons = _prototypeManager.EnumeratePrototypes<JobIconPrototype>().Where(icon => icon.AllowSelection).ToList();
            icons.Sort((x, y) => string.Compare(x.LocalizedJobName, y.LocalizedJobName, StringComparison.CurrentCulture));
            foreach (var jobIcon in icons)
            {
                String styleBase = StyleBase.ButtonOpenBoth;
                var modulo = i % JobIconColumnCount;
                if (modulo == 0)
                    styleBase = StyleBase.ButtonOpenRight;
                else if (modulo == JobIconColumnCount - 1)
                    styleBase = StyleBase.ButtonOpenLeft;

                // Generate buttons
                var jobIconButton = new Button
                {
                    Access = AccessLevel.Public,
                    StyleClasses = { styleBase },
                    MaxSize = new Vector2(42, 28),
                    Group = jobIconButtonGroup,
                    Pressed = currentJobIconId == jobIcon.ID,
                    ToolTip = jobIcon.LocalizedJobName
                };

                // Generate buttons textures
                var jobIconTexture = new TextureRect
                {
                    Texture = _spriteSystem.Frame0(jobIcon.Icon),
                    TextureScale = new Vector2(2.5f, 2.5f),
                    Stretch = TextureRect.StretchMode.KeepCentered,
                };

                jobIconButton.AddChild(jobIconTexture);
                jobIconButton.OnPressed += _ => OnJobIconChanged?.Invoke(jobIcon.ID);
                IconGrid.AddChild(jobIconButton);

                i++;
            }
        }

        public void SetCurrentName(string name)
        {
            NameLineEdit.Text = name;
        }

        public void SetCurrentJob(string job)
        {
            JobLineEdit.Text = job;
        }
    }
}
