using Robust.Client.UserInterface;

namespace Content.Client.Stylesheets
{
    public interface IStylesheetManager
    {
        Stylesheet SheetNano { get; }

        void Initialize();
    }
}
