using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response
{
    // Art.Framework.ApiNetwork.Api.Parameter.Response.CommonResponse
    public class CommonResponse
    {
        public ScreenTransitionType ScreenTransitionType;
        public string MessageCode;
        public string MessageText;
        public string MessageTextId;
        public long ResponseDatetime;
        public long OriginalResponseDatetime;
        public long MaintenanceDateTime;
        public string Token;
        public int AppVersionStatusType;
        public string DebugStackTrace;
        public string[] UpdateUserDataNames;
        public int[] AchievementIdList;
        public UpdatedUserData UpdatedUserData;

        public CommonResponse()
        {
            UpdatedUserData = new UpdatedUserData();
        }
    }
}
