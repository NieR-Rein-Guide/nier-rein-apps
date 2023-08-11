namespace NierReincarnation.Core.Dark.View.UserInterface.Text;

public static partial class UserInterfaceTextKey
{
    public static class Limited
    {
        private const string kUiPrefix = "ui.Outgame.Limited.";
        public static readonly string kRemainTime = kUiPrefix + "RemainTime";
        private const string kPrefix = "limited.open.";
        private const string kLocalPushPrefix = kPrefix + "local.push.";
        public static readonly string kLocalPush = kLocalPushPrefix + Common.kOneValueFormat;
        public static readonly string kLocalPushTitle = kLocalPushPrefix + "title." + Common.kOneValueFormat;
        public static readonly string kAchievement = kPrefix + "achievement." + Common.kOneValueFormat;
    }
}
