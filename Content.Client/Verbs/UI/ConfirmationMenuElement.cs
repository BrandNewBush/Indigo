﻿using Content.Client.ContextMenu.UI;
using Content.Shared.Verbs;
using Robust.Shared.Maths;
using Robust.Shared.Utility;

namespace Content.Client.Verbs.UI;

public sealed partial class ConfirmationMenuElement : ContextMenuElement
{
    public const string StyleClassConfirmationContextMenuButton = "confirmationContextMenuButton";

    public readonly Verb Verb;

    public override string Text
    {
        set => ItemLabel.Text = value.Trim();
    }

    public ConfirmationMenuElement(Verb verb, string? text) : base(text)
    {
        Verb = verb;
        Icon.Visible = false;

        SetOnlyStyleClass(StyleClassConfirmationContextMenuButton);
    }
}
