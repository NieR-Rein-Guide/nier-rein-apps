namespace NierReincarnation.Core.Adam.Framework.Network
{
    public class DarkNetworkError
    {
        // 0x10
        public string ErrorCode { get; }
        // 0x18
        public string Message { get; }
        // 0x20
        public ScreenTransitionType ScreenTransitionType { get; }

        public DarkNetworkError(string errorCode, string message, ScreenTransitionType type)
        {
            ErrorCode = errorCode;
            Message = message;
            ScreenTransitionType = type;
        }
    }

    public enum ScreenTransitionType
    {
        Success = 0,
        Stay = 1,
        FunctionTop = 2,
        Title = 3,
        StayAndUserAuth = 4,
        None = 5,
        FatalRetry = 8,
        FatalNoRetry = 9
    }
}
