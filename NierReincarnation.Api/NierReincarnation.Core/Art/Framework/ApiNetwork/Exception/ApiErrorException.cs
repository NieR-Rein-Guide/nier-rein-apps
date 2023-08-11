using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Exception;

public class ApiErrorException : System.Exception
{
    public readonly ScreenTransitionType ScreenTransitionType;
    public readonly string MessageId;
    public readonly string DebugTrace;

    public ApiErrorException(ResponseParameterBase response)
    {
        ScreenTransitionType = response.ScreenTransitionType;
        MessageId = response.MessageId;
        DebugTrace = response.GetCommon().DebugStackTrace;
    }
}
