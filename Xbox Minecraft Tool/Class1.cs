using JRPC_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDevkit;

namespace Xbox_Minecraft_Tool
{
    public class XNotify
    {
        public static IXboxConsole console;
        public static bool XNotifyActive { get => true; set=> Enabled; }
        public static bool XNotifyEnabled;
        public bool Enabled
        {
            get
            {
                return XNotifyEnabled;
            }
            set
            {
                XNotifyEnabled = value;
                XNotifyActive = true;
            }
        }
        public static void Show(string a)
        {
            XNotifyActive = true;
            if (XNotifyActive == true)//defualt is true for active false is for no message to show
            {
                object[] arguments = new object[] { 0x18, 0xff, 2, (a).ToWCHAR(), 1 };
                console.CallVoid(JRPC.ThreadType.Title, "xam.xex", 0x290, arguments);
            }
            else
            {

            }
        }
        public static void Show(XNotiyLogo Type, string Message)
        {
            XNotifyActive = true;
            if (XNotifyActive == true)
            {
                object[] arguments = new object[] { 0x18, 0xff, 2, (Message).ToWCHAR(), 1 };
                console.CallVoid(JRPC.ThreadType.Title, "xam.xex", 0x290, arguments);
            }
            else
            {

            }
        }
        public enum XNotiyLogo
        {
            XBOX_LOGO = 0,
            NEW_MESSAGE_LOGO = 1,
            FRIEND_REQUEST_LOGO = 2,
            NEW_MESSAGE = 3,
            FLASHING_XBOX_LOGO = 4,
            GAMERTAG_SENT_YOU_A_MESSAGE = 5,
            GAMERTAG_SINGED_OUT = 6,
            GAMERTAG_SIGNEDIN = 7,
            GAMERTAG_SIGNED_INTO_XBOX_LIVE = 8,
            GAMERTAG_SIGNED_IN_OFFLINE = 9,
            GAMERTAG_WANTS_TO_CHAT = 10,
            DISCONNECTED_FROM_XBOX_LIVE = 11,
            DOWNLOAD = 12,
            FLASHING_MUSIC_SYMBOL = 13,
            FLASHING_HAPPY_FACE = 14,
            FLASHING_FROWNING_FACE = 15,
            FLASHING_DOUBLE_SIDED_HAMMER = 16,
            GAMERTAG_WANTS_TO_CHAT_2 = 17,
            PLEASE_REINSERT_MEMORY_UNIT = 18,
            PLEASE_RECONNECT_CONTROLLERM = 19,
            GAMERTAG_HAS_JOINED_CHAT = 20,
            GAMERTAG_HAS_LEFT_CHAT = 21,
            GAME_INVITE_SENT = 22,
            FLASH_LOGO = 23,
            PAGE_SENT_TO = 24,
            FOUR_2 = 25,
            FOUR_3 = 26,
            ACHIEVEMENT_UNLOCKED = 27,
            FOUR_9 = 28,
            GAMERTAG_WANTS_TO_TALK_IN_VIDEO_KINECT = 29,
            VIDEO_CHAT_INVITE_SENT = 30,
            READY_TO_PLAY = 31,
            CANT_DOWNLOAD_X = 32,
            DOWNLOAD_STOPPED_FOR_X = 33,
            FLASHING_XBOX_CONSOLE = 34,
            X_SENT_YOU_A_GAME_MESSAGE = 35,
            DEVICE_FULL = 36,
            FOUR_7 = 37,
            FLASHING_CHAT_ICON = 38,
            ACHIEVEMENTS_UNLOCKED = 39,
            X_HAS_SENT_YOU_A_NUDGE = 40,
            MESSENGER_DISCONNECTED = 41,
            BLANK = 42,
            CANT_SIGN_IN_MESSENGER = 43,
            MISSED_MESSENGER_CONVERSATION = 44,
            FAMILY_TIMER_X_TIME_REMAINING = 45,
            DISCONNECTED_XBOX_LIVE_11_MINUTES_REMAINING = 46,
            KINECT_HEALTH_EFFECTS = 47,
            FOUR_5 = 48,
            GAMERTAG_WANTS_YOU_TO_JOIN_AN_XBOX_LIVE_PARTY = 49,
            PARTY_INVITE_SENT = 50,
            GAME_INVITE_SENT_TO_XBOX_LIVE_PARTY = 51,
            KICKED_FROM_XBOX_LIVE_PARTY = 52,
            NULLED = 53,
            DISCONNECTED_XBOX_LIVE_PARTY = 54,
            DOWNLOADED = 55,
            CANT_CONNECT_XBL_PARTY = 56,
            GAMERTAG_HAS_JOINED_XBL_PARTY = 57,
            GAMERTAG_HAS_LEFT_XBL_PARTY = 58,
            GAMER_PICTURE_UNLOCKED = 59,
            AVATAR_AWARD_UNLOCKED = 60,
            JOINED_XBL_PARTY = 61,
            PLEASE_REINSERT_USB_STORAGE_DEVICE = 62,
            PLAYER_MUTED = 63,
            PLAYER_UNMUTED = 64,
            FLASHING_CHAT_SYMBOL = 65,
            UPDATING = 76,
        }
    }
}
