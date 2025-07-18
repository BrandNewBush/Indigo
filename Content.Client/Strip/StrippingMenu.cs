using Content.Client.UserInterface.Controls;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Timing;
using static Robust.Client.UserInterface.Controls.BoxContainer;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Strip
{
    public sealed class StrippingMenu : UIKWindow
    {
        public LayoutContainer InventoryContainer = new();
        public BoxContainer HandsContainer = new() { Orientation = LayoutOrientation.Horizontal };
        public BoxContainer SnareContainer = new();
        public bool Dirty = true;

        public event Action? OnDirty;

        public StrippingMenu()
        {
            MinWidth = 280;

            var box = new BoxContainer() { Orientation = LayoutOrientation.Vertical, Margin = new Thickness(0, 8) };
            ContentsContainer.AddChild(box);
            box.AddChild(SnareContainer);
            box.AddChild(HandsContainer);
            box.AddChild(InventoryContainer);
        }

        public void ClearButtons()
        {
            InventoryContainer.DisposeAllChildren();
            HandsContainer.DisposeAllChildren();
            SnareContainer.DisposeAllChildren();
        }

        protected override void FrameUpdate(FrameEventArgs args)
        {
            base.FrameUpdate(args);

            if (!Dirty)
                return;

            Dirty = false;
            OnDirty?.Invoke();
        }
    }
}
