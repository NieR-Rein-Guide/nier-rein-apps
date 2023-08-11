using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class ErrorHandlingInterceptor : INetworkInterceptor
{
    public static Func<string, string, string, Task> StayError;
    public static Func<string, string, string, long, Task> MoveFunctionTopError;
    public static Func<string, string, string, string, long, Task> MoveTitleError;
    public static Func<Task> MoveTitleMaintenanceError;
    public static Func<Task> MoveTitlePermissionDeniedError;
    public static Func<Task> AuthRetryError;
    public static Func<StatusCode, string, Task> OtherFatalError;
    public static Func<bool> IsPossibleRetry;
    public static Func<Task> RetryErrorDialog;
    public static Func<string, Task> ClientFatalNetWorkError;
    public static bool IsRetrying;
    public static bool IsTitleError = false;
    private static readonly float kMilliSecondsUnit = 1000;

    public static Func<RpcException, Task<bool>> OnErrorAction;

    private int _retriedCount;
    private int _unavailableCount;
    private int _keepAliveRetriedCount;
    private string _errorDetailInfo;
    //private ConnectingInParameter _connectingInParameter;
    //private ConnectingOutParameter _connectingOutParameter;

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
