namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response
{
    // Art.Framework.ApiNetwork.Api.Parameter.Response.CommonResponse
    class CommonResponse
    {
        public int screenTransitionType; // 0x10
        public string messageCode; // 0x18
        public string messageText; // 0x20
        public string messageTextId; // 0x28
        public long responseDatetime; // 0x30
        public long originalResponseDatetime; // 0x38
        public long maintenanceDateTime; // 0x40
        public string token; // 0x48
        public int appVersionStatusType; // 0x50
        public string debugStackTrace; // 0x58
        public string[] updateUserDataNames; // 0x60
        public int[] achievementIdList; // 0x68
        public UpdatedUserData updatedUserData; // 0x70

        public CommonResponse()
        {
            updatedUserData = new UpdatedUserData();
        }
    }
}
