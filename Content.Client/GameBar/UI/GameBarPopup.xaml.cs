// Copyright (C) 2025 Igor Spichkin

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Content.Client.UIKit.Controls;
using Content.Client.UserInterface.Controls;
using Content.Shared.Localizations;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;


namespace Content.Client.GameBar.UI;


[GenerateTypedNameReferences]
public sealed partial class GameBarPopup : UIKPopup
{
    public event ItemClickedCallback? ItemClicked;

    public GameBarPopup()
    {
        RobustXamlLoader.Load(this);
    }

    public void SetItems(IReadOnlyCollection<Item> items)
    {
        MenuPanel.RemoveAllChildren();

        foreach (var item in items)
        {
            var itemButton = new GameBarPopupItem(item.Name, item.HotKey);
            itemButton.OnButtonDown += _ => ItemClicked?.Invoke(item.Name);

            MenuPanel.AddChild(itemButton);
        }
    }

    public record struct Item(LocalizedString Name, string? HotKey);

    public delegate void ItemClickedCallback(LocalizedString item);
}
