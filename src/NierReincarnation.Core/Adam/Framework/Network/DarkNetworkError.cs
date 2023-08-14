using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Adam.Framework.Network;

public class DarkNetworkError
{
    private readonly string ErrorCode;
    private readonly string Message;
    private readonly ScreenTransitionType ScreenTransitionType;

    public DarkNetworkError(string errorCode, string message, ScreenTransitionType type)
    {
        ErrorCode = errorCode;
        Message = message;
        ScreenTransitionType = type;
    }
}
