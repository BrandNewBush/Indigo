using Content.Client.UserInterface.Controls;
using Content.Shared.Cargo;
using Content.Shared.Cargo.Prototypes;
using Robust.Client.AutoGenerated;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using UIKWindow = Content.Client.UIKit.Controls.UIKWindow;


namespace Content.Client.Cargo.UI
{
    [GenerateTypedNameReferences]
    public sealed partial class CargoShuttleMenu : UIKWindow
    {
        public CargoShuttleMenu()
        {
            RobustXamlLoader.Load(this);
            Title = Loc.GetString("cargo-shuttle-console-menu-title");
        }

        public void SetAccountName(string name)
        {
            AccountNameLabel.Text = name;
        }

        public void SetShuttleName(string name)
        {
            ShuttleNameLabel.Text = name;
        }

        public void SetOrders(SpriteSystem sprites, IPrototypeManager protoManager, List<CargoOrderData> orders)
        {
            Orders.DisposeAllChildren();

            foreach (var order in orders)
            {
                 var product = protoManager.Index<EntityPrototype>(order.ProductId);
                 var productName = product.Name;

                 var row = new CargoOrderRow
                 {
                     Order = order,
                     Icon = { Texture = sprites.Frame0(product) },
                     ProductName =
                     {
                         Text = Loc.GetString(
                             "cargo-console-menu-populate-orders-cargo-order-row-product-name-text",
                             ("productName", productName),
                             ("orderAmount", order.OrderQuantity - order.NumDispatched),
                             ("orderRequester", order.Requester))
                     },
                     Description = {Text = Loc.GetString("cargo-console-menu-order-reason-description",
                         ("reason", order.Reason))}
                 };

                 row.Approve.Visible = false;
                 row.Cancel.Visible = false;

                 Orders.AddChild(row);
            }
        }
    }
}
