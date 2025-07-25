﻿using Content.Client.GameBar;
using Content.Client.Ghost;
using Content.Client.UserInterface.Systems.Gameplay;
using Content.Client.UserInterface.Systems.Ghost.Widgets;
using Content.Shared.Ghost;
using Content.Shared.Input;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;


namespace Content.Client.UserInterface.Systems.Ghost;


// TODO hud refactor BEFORE MERGE fix ghost gui being too far up
public sealed class GhostUIController : UIController, IOnSystemChanged<GhostSystem>
{
    [Dependency] private readonly IEntityNetworkManager _net               = default!;
    [Dependency] private readonly GameBarManager     _gameBarManager = null!;

    [UISystemDependency] private readonly GhostSystem? _system = default;

    private GhostGui? Gui => UIManager.GetActiveUIWidgetOrNull<GhostGui>();

    public override void Initialize()
    {
        base.Initialize();

        var gameplayStateLoad = UIManager.GetUIController<GameplayStateLoadController>();
        gameplayStateLoad.OnScreenLoad   += OnScreenLoad;
        gameplayStateLoad.OnScreenUnload += OnScreenUnload;

        _gameBarManager
            .GetCategory(GameBarCategory.Ghost)
            .RegisterItem(
                new(
                    new("global-menu-ghost-warp-item"),
                    Function: ContentKeyFunctions.GhostWarp,
                    Callback: RequestWarps
                )
            )
            .RegisterItem(
                new(
                    new("global-menu-ghost-return-to-body-item"),
                    Function: ContentKeyFunctions.GhostReturnToBody,
                    Callback: ReturnToBody
                )
            )
            .RegisterItem(
                new(
                    new("global-menu-ghost-roles-item"),
                    Function: ContentKeyFunctions.GhostRoles,
                    Callback: GhostRolesPressed
                )
            )
            .RegisterItem(
                new(
                    new("global-menu-ghost-return-to-round-item"),
                    Function: ContentKeyFunctions.GhostReturnToRound,
                    Callback: ReturnToRound
                )
            )
            .RegisterItem(
                new(
                    new("global-menu-ghost-bar-item"),
                    Function: ContentKeyFunctions.GhostBar,
                    Callback: GhostBarPressed
                )
            );
    }

    private void OnScreenLoad()
    {
        LoadGui();
    }

    private void OnScreenUnload()
    {
        UnloadGui();
    }

    public void OnSystemLoaded(GhostSystem system)
    {
        system.PlayerRemoved         += OnPlayerRemoved;
        system.PlayerUpdated         += OnPlayerUpdated;
        system.PlayerAttached        += OnPlayerAttached;
        system.PlayerDetached        += OnPlayerDetached;
        system.GhostWarpsResponse    += OnWarpsResponse;
        system.GhostRoleCountUpdated += OnRoleCountUpdated;
    }

    public void OnSystemUnloaded(GhostSystem system)
    {
        system.PlayerRemoved         -= OnPlayerRemoved;
        system.PlayerUpdated         -= OnPlayerUpdated;
        system.PlayerAttached        -= OnPlayerAttached;
        system.PlayerDetached        -= OnPlayerDetached;
        system.GhostWarpsResponse    -= OnWarpsResponse;
        system.GhostRoleCountUpdated -= OnRoleCountUpdated;
    }

    public void UpdateGui()
    {
        if (Gui == null)
        {
            return;
        }

        Gui.Visible = _system?.IsGhost ?? false;
        Gui.Update(_system?.AvailableGhostRoleCount, _system?.Player?.CanReturnToBody);
    }

    private void OnPlayerRemoved(GhostComponent component)
    {
        Gui?.Hide();
    }

    private void OnPlayerUpdated(GhostComponent component)
    {
        UpdateGui();
    }

    private void OnPlayerAttached(GhostComponent component)
    {
        if (Gui == null)
            return;

        Gui.Visible = true;
        UpdateGui();
    }

    private void OnPlayerDetached()
    {
        Gui?.Hide();
        UpdateGui();
    }

    private void OnWarpsResponse(GhostWarpsResponseEvent msg)
    {
        if (Gui?.TargetWindow is not { } window)
            return;

        window.UpdateWarps(msg.Warps);
        window.Populate();
    }

    private void OnRoleCountUpdated(GhostUpdateGhostRoleCountEvent msg)
    {
        UpdateGui();
    }

    private void OnWarpClicked(NetEntity player)
    {
        var msg = new GhostWarpToTargetRequestEvent(player);
        _net.SendSystemNetworkMessage(msg);
    }

    private void OnGhostnadoClicked()
    {
        var msg = new GhostnadoRequestEvent();
        _net.SendSystemNetworkMessage(msg);
    }

    public void LoadGui()
    {
        if (Gui == null)
            return;

        Gui.RequestWarpsPressed               += RequestWarps;
        Gui.ReturnToBodyPressed               += ReturnToBody;
        Gui.GhostRolesPressed                 += GhostRolesPressed;
        Gui.GhostBarPressed                   += GhostBarPressed;      // Goobstation - Ghost Bar
        Gui.GhostBarWindow.SpawnButtonPressed += GhostBarSpawnPressed; // Goobstation - Ghost Bar
        Gui.TargetWindow.WarpClicked          += OnWarpClicked;
        Gui.TargetWindow.OnGhostnadoClicked   += OnGhostnadoClicked;
        Gui.ReturnToRoundPressed              += ReturnToRound;

        UpdateGui();
    }

    public void UnloadGui()
    {
        if (Gui == null)
            return;

        Gui.RequestWarpsPressed               -= RequestWarps;
        Gui.ReturnToBodyPressed               -= ReturnToBody;
        Gui.GhostRolesPressed                 -= GhostRolesPressed;
        Gui.GhostBarPressed                   -= GhostBarPressed;      // Goobstation - Ghost Bar
        Gui.GhostBarWindow.SpawnButtonPressed -= GhostBarSpawnPressed; // Goobstation - Ghost Bar
        Gui.TargetWindow.WarpClicked          -= OnWarpClicked;
        Gui.ReturnToRoundPressed              -= ReturnToRound;

        Gui.Hide();
    }

    private void ReturnToBody()
    {
        _system?.ReturnToBody();
    }

    private void ReturnToRound()
    {
        _system?.ReturnToRound();
    }

    private void RequestWarps()
    {
        _system?.RequestWarps();
        Gui?.TargetWindow.Populate();
        Gui?.TargetWindow.OpenCentered();
    }

    private void GhostRolesPressed()
    {
        _system?.OpenGhostRoles();
    }

    private void GhostBarPressed() // Goobstation - Ghost Bar
    {
        Gui?.GhostBarWindow.OpenCentered();
    }

    private void GhostBarSpawnPressed() // Goobstation - Ghost Bar
    {
        _system?.GhostBarSpawn();
    }
}
