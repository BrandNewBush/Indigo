using Content.Client.Administration.Managers;
using Content.Client.Chat.Managers;
using Content.Client.Clickable;
using Content.Client.DeltaV.NanoChat;
using Content.Client.DiscordAuth;
using Content.Client.JoinQueue;
using Content.Client.DebugMon;
using Content.Client.DrawKit;
using Content.Client.Eui;
using Content.Client.Fullscreen;
using Content.Client.GameBar;
using Content.Client.GhostKick;
using Content.Client.Guidebook;
using Content.Client.UIKit;
using Content.Client.KeyPresets;
using Content.Client.Launcher;
using Content.Client.Mapping;
using Content.Client.Parallax.Managers;
using Content.Client.Players.PlayTimeTracking;
using Content.Client.Replay;
using Content.Client.Screenshot;
using Content.Client.Stylesheets;
using Content.Client.Viewport;
using Content.Client.Voting;
using Content.Shared.Administration.Logs;
using Content.Client.Lobby;
using Content.Client.Players.RateLimiting;
using Content.Shared.Administration.Managers;
using Content.Shared.Chat;
using Content.Shared.Players.PlayTimeTracking;
using Content.Shared.Players.RateLimiting;


namespace Content.Client.IoC
{
    internal static class ClientContentIoC
    {
        public static void Register()
        {
            var collection = IoCManager.Instance!;

            collection.Register<IParallaxManager, ParallaxManager>();
            collection.Register<IChatManager, ChatManager>();
            collection.Register<ISharedChatManager, ChatManager>();
            collection.Register<IClientPreferencesManager, ClientPreferencesManager>();
            collection.Register<IStylesheetManager, StylesheetManager>();
            collection.Register<IScreenshotHook, ScreenshotHook>();
            collection.Register<FullscreenHook, FullscreenHook>();
            collection.Register<IClickMapManager, ClickMapManager>();
            collection.Register<IClientAdminManager, ClientAdminManager>();
            collection.Register<ISharedAdminManager, ClientAdminManager>();
            collection.Register<EuiManager, EuiManager>();
            collection.Register<IVoteManager, VoteManager>();
            collection.Register<ViewportManager, ViewportManager>();
            collection.Register<ISharedAdminLogManager, SharedAdminLogManager>();
            collection.Register<GhostKickManager>();
            collection.Register<ExtendedDisconnectInformationManager>();
            collection.Register<JobRequirementsManager>();
            collection.Register<DocumentParsingManager>();
            collection.Register<ContentReplayPlaybackManager>();
            collection.Register<ISharedPlaytimeManager, JobRequirementsManager>();
            collection.Register<JoinQueueManager>();
            collection.Register<DiscordAuthManager>();
            collection.Register<PlayerRateLimitManager>();
            collection.Register<SharedPlayerRateLimitManager, PlayerRateLimitManager>();
            collection.Register<NanoChatSystem>();
            collection.Register<MappingManager>();
            collection.Register<DebugMonitorManager>();
            collection.Register<TypographyManager>();
            collection.Register<KeyPresetsManager>();
            collection.Register<GameBarManager>();
            collection.Register<DrawKitManager>();
        }
    }
}
