using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors
{
    public class ErrorHandlingInterceptor : INetworkInterceptor
    {
        public static Func<string, string, string, Task> StayError; // 0x0
        public static Func<string, string, string, long, Task> MoveFunctionTopError; // 0x8
        public static Func<string, string, string, string, long, Task> MoveTitleError; // 0x10
        public static Func<Task> MoveTitleMaintenanceError; // 0x18
        public static Func<Task> MoveTitlePermissionDeniedError; // 0x20
        public static Func<Task> AuthRetryError; // 0x28
        public static Func<StatusCode, string, Task> OtherFatalError; // 0x30
        public static Func<bool> IsPossibleRetry; // 0x38
        public static Func<Task> RetryErrorDialog; // 0x40
        public static Func<string, Task> ClientFatalNetWorkError; // 0x48
        public static bool IsRetrying; // 0x50
        public static bool IsTitleError = false; // 0x51
        private static readonly float kMilliSecondsUnit = 1000; // 0x54

        public static Func<RpcException, Task<bool>> OnErrorAction;

        private int _retriedCount; // 0x10
        private int _unavailableCount; // 0x14
        private int _keepAliveRetriedCount; // 0x18
        private string _errorDetailInfo; // 0x20
        //private ConnectingInParameter _connectingInParameter; // 0x28
        //private ConnectingOutParameter _connectingOutParameter; // 0x30

        public ErrorHandlingInterceptor()
        {
            // Set connecting parameters
        }

        public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
        {
            // CUSTOM: Try-Catch RpcException of type "PreconditionFailed" to notify the user that the current version of the app should be updated
            try
            {
                var result = await next.Invoke(context);

                return await result.WaitResponseAsync();
            }
            catch (RpcException rpce)
            {
                if (OnErrorAction != null)
                    await OnErrorAction(rpce);
            }

            return default;
        }

        //private UniTask<ScreenTransitionType> ErrorHandling(RpcException ex)
        //{

        //}

        //private bool IsRetryStatus(StatusCode statusCode)
        //{

        //}

        //private UniTask<bool> IsReachableMaintenanceHtml()
        //{

        //}

        //private int GetRetryCount(StatusCode statusCode)
        //{

        //}
    }
}
