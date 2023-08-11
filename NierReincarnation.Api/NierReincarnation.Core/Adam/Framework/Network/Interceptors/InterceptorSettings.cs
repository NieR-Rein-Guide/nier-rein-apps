using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors
{
    // Adam.Framework.Network.Interceptors.InterceptorSettings
    static class InterceptorSettings
    {
        public static readonly int MaxRetryCount = 3;
        public static readonly int TimeoutMaxRetryCount = 2;
        public static readonly int[] RetryIntervals = new int[3];
        public static readonly StatusCode[] RetryStatusCodes = new StatusCode[4];
        public static readonly string KeepAliveTimeOutErrorString = "keepalive watchdog timeout";
        public static readonly int WaitTimeout = 60000;
        public static readonly int MAXRequestNo = 100000;
        public static readonly string UserDiffRequest = "DataService/GetDiffUserDataAsync";
        public static readonly string AndroidArgsRequest = "UserService/GetAndroidArgsAsync";
        public static readonly string UserRegisterRequest = "UserService/AuthAsync";
        public static readonly string AuthRequest = "UserService/RegisterUserAsync";   
        public static readonly string ServerConfigRequest = "ConfigService/GetReviewServerConfigAsync";
        public static readonly string FinishWaveRequest = "BattleService/FinishWaveAsync";
        public static readonly string FinishMainQuestRequest = "QuestService/FinishMainQuestAsync";
        public static readonly string FinishEventQuestRequest = "QuestService/FinishEventQuestAsync";
        public static readonly string FinishExtraQuestRequest = "QuestService/FinishExtraQuestAsync";
        public static readonly string FinishBigHuntQuestRequest = "BigHuntService/FinishBigHuntQuestAsync";
        public static readonly string FinishExploreRequest = "ExploreService/FinishExploreAsync";
        public static readonly string SaveBigHuntBattleInfo = "BigHuntService/SaveBigHuntBattleInfoAsync";
        public static readonly string[] IgnoreErrorCodes = { "290041", "290043", "290044" };
    }
}
