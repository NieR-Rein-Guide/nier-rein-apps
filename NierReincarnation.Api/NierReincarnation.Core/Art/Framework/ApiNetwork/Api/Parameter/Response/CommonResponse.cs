using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response
{
    // Art.Framework.ApiNetwork.Api.Parameter.Response.CommonResponse
    public class CommonResponse
    {
        public ScreenTransitionType ScreenTransitionType; // 0x10
        public string MessageCode; // 0x18
        public string MessageText; // 0x20
        public string MessageTextId; // 0x28
        public long ResponseDatetime; // 0x30
        public long OriginalResponseDatetime; // 0x38
        public long MaintenanceDateTime; // 0x40
        public string Token; // 0x48
        public int AppVersionStatusType; // 0x50
        public string DebugStackTrace; // 0x58
        public string[] UpdateUserDataNames; // 0x60
        public int[] AchievementIdList; // 0x68
        public UpdatedUserData UpdatedUserData; // 0x70

        public CommonResponse()
        {
            UpdatedUserData = new UpdatedUserData();
        }
    }
}
