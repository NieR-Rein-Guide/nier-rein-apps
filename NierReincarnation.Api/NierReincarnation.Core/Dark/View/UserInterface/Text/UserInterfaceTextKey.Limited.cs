namespace NierReincarnation.Core.Dark.View.UserInterface.Text
{
    public static partial class UserInterfaceTextKey
    {
        public static class Limited
        {
            private const string kUiPrefix = "ui.Outgame.Limited."; // 0x0
            public static readonly string kRemainTime = kUiPrefix + "RemainTime"; // 0x8
            private const string kPrefix = "limited.open."; // 0x10
            private const string kLocalPushPrefix = kPrefix + "local.push."; // 0x18
            public static readonly string kLocalPush = kLocalPushPrefix + Common.kOneValueFormat; // 0x20
            public static readonly string kLocalPushTitle = kLocalPushPrefix + "title." + Common.kOneValueFormat; // 0x28
            public static readonly string kAchievement = kPrefix + "achievement." + Common.kOneValueFormat; // 0x30
        }
    }
}
