using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Exception
{
    // Art.Framework.ApiNetwork.Exception.ApiErrorException
    class ApiErrorException : System.Exception
    {
        public readonly int ScreenTransitionType; // 0x88
        public readonly string MessageId; // 0x90
        public readonly string DebugTrace; // 0x98

        public ApiErrorException(ResponseParameterBase response)
        {
            ScreenTransitionType = response.ScreenTransitionType;
            MessageId = response.MessageId;
            DebugTrace = response.GetCommon().debugStackTrace;
        }
    }
}
