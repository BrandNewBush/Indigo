## General stuff

ui-options-title = Game Options
ui-options-tab-graphics = Graphics
ui-options-tab-controls = Controls
ui-options-tab-audio = Audio
ui-options-tab-network = Network
ui-options-tab-misc = General

ui-options-apply = Apply
ui-options-reset-all = Reset All
ui-options-default = Default

# Misc/General menu

ui-options-discordrich = Enable Discord Rich Presence
ui-options-general-ui-style = UI Style
ui-options-general-discord = Discord
ui-options-general-cursor = Cursor
ui-options-general-speech = Speech
ui-options-general-storage = Storage
ui-options-general-other = Other
ui-options-general-accessibility = Accessibility
ui-options-chatstack = Automatically merge identical chat messages
ui-options-chatstack-off = Off
ui-options-chatstack-single = Only last message
ui-options-chatstack-double = Last two messages
ui-options-chatstack-triple = Last three messages

## Audio menu

ui-options-master-volume = Master Volume:
ui-options-midi-volume = MIDI (Instrument) Volume:
ui-options-ambient-music-volume = Ambient music volume:
ui-options-ambience-volume = Ambience volume:
ui-options-lobby-volume = Lobby & Round-end volume:
ui-options-interface-volume = Interface volume:
ui-options-ambience-max-sounds = Ambience simultaneous sounds:
ui-options-announcer-volume = Announcer volume:
ui-options-lobby-music = Lobby & Round-end Music
ui-options-restart-sounds = Round Restart Sounds
ui-options-event-music = Event Music
ui-options-announcer-disable-multiple-sounds = Disable Overlapping Announcer Sounds
ui-options-announcer-disable-multiple-sounds-tooltip = Some announcements will not sound right, this setting isn't recommended
ui-options-admin-sounds = Play Admin Sounds
ui-options-volume-label = Volume
ui-options-volume-percent = { TOSTRING($volume, "P0") }

## Graphics menu

ui-options-show-held-item = Show held item next to cursor
ui-options-show-combat-mode-indicators = Show combat mode indicators with cursor
ui-options-show-offer-mode-indicators = Show offer mode indicators with cursor
ui-options-opaque-storage-window = Opaque storage window
ui-options-show-ooc-patron-color = Show OOC Patreon color
ui-options-show-looc-on-head = Show LOOC chat above characters head
ui-options-fancy-speech = Show names in speech bubbles
ui-options-fancy-name-background = Add background to speech bubble names
ui-options-enable-color-name = Add colors to character names
ui-options-colorblind-friendly = Colorblind friendly mode
ui-options-no-filters = Disable species vision filters
ui-options-reduced-motion = Reduce motion of visual effects
ui-options-chat-window-opacity = Chat window opacity
ui-options-chat-window-opacity-percent = { TOSTRING($opacity, "P0") }
ui-options-screen-shake-intensity = Screen shake intensity
ui-options-screen-shake-percent = { TOSTRING($intensity, "P0") }
ui-options-vsync = VSync
ui-options-fullscreen = Fullscreen
ui-options-lighting-label = Lighting Quality:
ui-options-lighting-very-low = Very Low
ui-options-lighting-low = Low
ui-options-lighting-medium = Medium
ui-options-lighting-high = High
ui-options-scale-label = UI Scale:
ui-options-scale-auto = Automatic ({ TOSTRING($scale, "P0") })
ui-options-scale-75 = 75%
ui-options-scale-100 = 100%
ui-options-scale-125 = 125%
ui-options-scale-150 = 150%
ui-options-scale-175 = 175%
ui-options-scale-200 = 200%
ui-options-hud-theme = HUD theme:
ui-options-hud-theme-default = Default
ui-options-hud-theme-plasmafire = Plasmafire
ui-options-hud-theme-slimecore = Slimecore
ui-options-hud-theme-clockwork = Clockwork
ui-options-hud-theme-retro = Retro
ui-options-hud-theme-minimalist = Minimalist
ui-options-hud-theme-ashen = Ashen
ui-options-vp-stretch = Stretch viewport to fit game window
ui-options-vp-scale = Fixed viewport scale: x{ $scale }
ui-options-vp-integer-scaling = Prefer integer scaling (might cause black bars/clipping)
ui-options-vp-integer-scaling-tooltip = If this option is enabled, the viewport will be scaled using an integer value
                                        at specific resolutions. While this results in crisp textures, it also often
                                        means that black bars appear at the top/bottom of the screen or that part
                                        of the viewport is not visible.
ui-options-vp-vertical-fit = Vertical viewport fitting
ui-options-vp-vertical-fit-tooltip = When enabled, the main viewport will ignore the horizontal axis entirely when
                                     fitting to your screen. If your screen is smaller than the viewport, then this
                                     will cause the viewport to be cut off on the horizontal axis.
ui-options-vp-low-res = Low-resolution viewport
ui-options-parallax-low-quality = Low-quality Parallax (background)
ui-options-fps-counter = Show FPS counter
ui-options-mood-visual-effects = Enable the mood system's visual effects
ui-options-vp-width = Viewport width: { $width }
ui-options-hud-layout = HUD layout:

## Controls menu

ui-options-binds-reset-all = Reset ALL keybinds
ui-options-binds-explanation = Click to change binding, right-click to clear
ui-options-binds-search = Search
ui-options-binds-keys-preset = Preset
ui-options-binds-apply-keys-preset = Apply
ui-options-unbound = Unbound
ui-options-bind-reset = Reset
ui-options-key-prompt = Press a key...

ui-options-hotkey-keymap = Use US QWERTY Keys

## Global

ui-options-header-global = Global

ui-options-function-examine-entity = Examine
ui-options-function-open-a-help = Open admin help
ui-options-function-open-abilities-menu = Open action menu
ui-options-function-open-admin-menu = Open admin menu
ui-options-function-open-character-menu = Open character menu
ui-options-function-open-crafting-menu = Open crafting menu
ui-options-function-open-decal-spawn-window = Open decal spawn menu
ui-options-function-open-entity-spawn-window = Open entity spawn menu
ui-options-function-open-guidebook = Open guidebook
ui-options-function-open-language-window = Open language window
ui-options-function-open-options-window = Open options window
ui-options-function-open-sandbox-window = Open sandbox menu
ui-options-function-open-tile-spawn-window = Open tile spawn menu
ui-options-function-take-screenshot = Take screenshot
ui-options-function-take-screenshot-no-ui = Take screenshot (without UI)
ui-options-function-toggle-fullscreen = Toggle fullscreen
ui-options-function-toggle-round-end-summary-window = Toggle round end summary window
ui-options-function-open-context-menu = Open context menu
ui-options-function-show-escape-menu = Toggle game menu

## Movement

ui-options-header-movement = Movement

ui-options-hotkey-toggle-walk = Toggle Speed
ui-options-hotkey-default-walk = Walk by default

ui-options-function-move-up = Move Up
ui-options-function-move-left = Move Left
ui-options-function-move-down = Move Down
ui-options-function-move-right = Move Right
ui-options-function-walk = Change Speed

## Camera

ui-options-header-camera = Camera

ui-options-function-camera-rotate-left = Rotate left
ui-options-function-camera-rotate-right = Rotate right
ui-options-function-camera-reset = Reset
ui-options-function-zoom-in = Zoom in
ui-options-function-zoom-out = Zoom out
ui-options-function-reset-zoom = Reset zoom

## Character

ui-options-header-character = Character

ui-options-function-auto-get-up = Automatically get up after falling
ui-options-function-hold-look-up = Hold down the key to aim
ui-options-function-use = Use
ui-options-function-use-secondary = Use secondary
ui-options-function-activate-item-in-world = Activate item in world
ui-options-function-alt-activate-item-in-world = Alternative activate item in world
ui-options-function-activate-item-in-hand = Activate item in hand
ui-options-function-alt-activate-item-in-hand = Alternative activate item in hand
ui-options-function-throw-item-in-hand = Throw item
ui-options-function-drop = Drop item
ui-options-function-swap-hands = Swap hands
ui-options-function-toggle-standing = Toggle standing
ui-options-function-toggle-crawling-under = Toggle crawling under furniture
ui-options-function-try-pull-object = Pull object
ui-options-function-move-pulled-object = Move pulled object
ui-options-function-release-pulled-object = Release pulled object
ui-options-function-point = Point at location
ui-options-function-offer-item = Offer something
ui-options-function-look-up = Look up/Take aim

## Inventory

ui-options-header-inventory = Inventory

ui-options-function-open-inventory-menu = Open inventory
ui-options-function-open-backpack = Open backpack
ui-options-function-open-belt = Open belt
ui-options-function-smart-equip-backpack = Smart-equip to backpack
ui-options-function-smart-equip-belt = Smart-equip to belt
ui-options-function-move-stored-item = Move stored item
ui-options-function-rotate-stored-item = Rotate stored item
ui-options-function-save-item-location = Save item location

## Chat

ui-options-header-chat = Chat

ui-options-function-focus-chat-input-window = Focus chat
ui-options-function-focus-radio-window = Focus chat (Radio)
ui-options-function-focus-local-chat-window = Focus chat (IC)
ui-options-function-focus-whisper-chat-window = Focus chat (Whisper)
ui-options-function-focus-emote = Focus chat (Emote)
ui-options-function-focus-ooc-window = Focus chat (OOC)
ui-options-function-focus-looc-window = Focus chat (LOOC)
ui-options-function-focus-dead-chat-window = Focus chat (Dead)
ui-options-function-focus-admin-chat-window = Focus chat (Admin)
ui-options-function-cycle-chat-channel-forward = Cycle channel (Forward)
ui-options-function-cycle-chat-channel-backward = Cycle channel (Backward)

## Actions Bar

ui-options-header-actions-bar = Actions Bar

ui-options-function-hotbar1 = Hotbar slot 1
ui-options-function-hotbar2 = Hotbar slot 2
ui-options-function-hotbar3 = Hotbar slot 3
ui-options-function-hotbar4 = Hotbar slot 4
ui-options-function-hotbar5 = Hotbar slot 5
ui-options-function-hotbar6 = Hotbar slot 6
ui-options-function-hotbar7 = Hotbar slot 7
ui-options-function-hotbar8 = Hotbar slot 8
ui-options-function-hotbar9 = Hotbar slot 9
ui-options-function-hotbar0 = Hotbar slot 0

ui-options-function-loadout1 = Hotbar Loadout 1
ui-options-function-loadout2 = Hotbar Loadout 2
ui-options-function-loadout3 = Hotbar Loadout 3
ui-options-function-loadout4 = Hotbar Loadout 4
ui-options-function-loadout5 = Hotbar Loadout 5
ui-options-function-loadout6 = Hotbar Loadout 6
ui-options-function-loadout7 = Hotbar Loadout 7
ui-options-function-loadout8 = Hotbar Loadout 8
ui-options-function-loadout9 = Hotbar Loadout 9
ui-options-function-loadout0 = Hotbar Loadout 0

## Targeting

ui-options-header-targeting = Targeting

ui-options-function-target-head = Target head
ui-options-function-target-torso = Target torso
ui-options-function-target-left-arm = Target left arm
ui-options-function-target-right-arm = Target right arm
ui-options-function-target-left-hand = Target left hand
ui-options-function-target-right-hand = Target right hand
ui-options-function-target-left-leg = Target left leg
ui-options-function-target-right-leg = Target right leg
ui-options-function-target-right-foot = Target right foot
ui-options-function-target-left-foot = Target left foot

## Ghost

ui-options-header-ghost = Ghost

ui-options-function-ghost-bar = Ghost bar
ui-options-function-ghost-return-to-body = Return to body
ui-options-function-ghost-return-to-round = Return to round
ui-options-function-ghost-roles = Open roles window
ui-options-function-ghost-warp = Open warp window

## Shuttle

ui-options-header-shuttle = Shuttle

ui-options-function-shuttle-strafe-up = Strafe up
ui-options-function-shuttle-strafe-right = Strafe right
ui-options-function-shuttle-strafe-left = Strafe left
ui-options-function-shuttle-strafe-down = Strafe down
ui-options-function-shuttle-rotate-left = Rotate left
ui-options-function-shuttle-rotate-right = Rotate right
ui-options-function-shuttle-brake = Brake

## Map Editor

ui-options-header-map-editor = Map Editor

ui-options-function-inspect-entity = Inspect Entity
ui-options-function-editor-copy-object = Copy
ui-options-function-editor-flip-object = Flip
ui-options-function-mapping-enable-decal-pick = Pick decal
ui-options-function-mapping-enable-delete = Delete object
ui-options-function-mapping-enable-pick = Pick object/tile
ui-options-function-editor-cancel-place = Cancel placement
ui-options-function-editor-grid-place = Place in grid
ui-options-function-editor-line-place = Place line
ui-options-function-editor-place-object = Place object
ui-options-function-editor-rotate-object = Rotate

## Developer

ui-options-header-developer = Developer

ui-options-function-show-debug-console = Open Console
ui-options-function-show-debug-monitors = Show Debug Monitors
ui-options-function-hide-ui = Hide UI

## System

ui-options-header-system = System

ui-options-function-text-copy = Copy Text
ui-options-function-text-paste = Paste Text
ui-options-function-text-cut = Cut Text
ui-options-function-text-select-all = Select All Text
ui-options-function-text-delete = Delete

ui-options-static-storage-ui = Lock storage window to hotbar
ui-options-modern-progress-bar = Modern progress bar

## Network menu

ui-options-net-predict = Client-side prediction

ui-options-net-interp-ratio = State buffer size
ui-options-net-interp-ratio-tooltip = Increasing this will generally make the game more resistant
                                      to server->client packet-loss, however in doing so it
                                      effectively adds slightly more latency and requires the
                                      client to predict more future ticks.

ui-options-net-predict-tick-bias = Prediction tick bias
ui-options-net-predict-tick-bias-tooltip = Increasing this will generally make the game more resistant
                                           to client->server packet-loss, however in doing so it
                                           effectively adds slightly more latency and requires the
                                           client to predict more future ticks.

ui-options-net-pvs-spawn = PVS entity spawn budget
ui-options-net-pvs-spawn-tooltip = This limits the rate at which the server will send newly spawned
                                       entities to the client. Lowering this can help reduce
                                       stuttering due to entity spawning, but can lead to pop-in.

ui-options-net-pvs-entry = PVS entity budget
ui-options-net-pvs-entry-tooltip = This limits the rate at which the server will send newly visible
                                       entities to the client. Lowering this can help reduce
                                       stuttering, but can lead to pop-in.

ui-options-net-pvs-leave = PVS detach rate
ui-options-net-pvs-leave-tooltip = This limits the rate at which the client will remove
                                       out-of-view entities. Lowering this can help reduce
                                       stuttering when walking around, but could occasionally
                                       lead to mispredicts and other issues.

## Toggle window console command
cmd-options-desc = Opens options menu, optionally with a specific tab selected.
cmd-options-help = Usage: options [tab]

## Combat Options
