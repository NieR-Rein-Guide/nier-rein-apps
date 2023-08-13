using Grpc.Core;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class ErrorHandlingInterceptor : INetworkInterceptor
{
    // Fields
    public static Func<string, string, string, Task> StayError;

    public static Func<string, string, string, long, Task> MoveFunctionTopError;
    public static Func<string, string, string, string, long, Task> MoveTitleError;
    public static Func<Task> MoveTitleMaintenanceError;
    public static Func<Task> MoveTitlePermissionDeniedError;
    public static Func<Task> AuthRetryError;
    public static Func<Grpc.Core.StatusCode, string, Task> OtherFatalError;
    public static Func<bool> IsPossibleRetry;
    public static Func<Task> RetryErrorDialog;
    public static Func<string, Task> ClientFatalNetWorkError;
    public static bool IsRetrying;
    public static bool IsTitleError;
    private const float kMilliSecondsUnit = 1000f;

    public static Func<RpcException, Task<bool>> OnErrorAction;

    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        try
        {
            var responseContext = await next.Invoke(context);
            return await responseContext.WaitResponseAsync();
        }
        catch (RpcException rpce)
        {
            if (OnErrorAction != null)
            {
                await OnErrorAction(rpce);
            }
        }

        return default;
    }

    // TODO
    private async Task<ScreenTransitionType> ErrorHandling(RpcException ex) => ScreenTransitionType.None;

    private bool IsRetryStatus(StatusCode statusCode) => InterceptorSettings.RetryStatusCodes.Any(x => x == statusCode);

    // TODO
    private async Task<bool> IsReachableMaintenanceHtml() => false;

    private int GetRetryCount(StatusCode statusCode) => statusCode == StatusCode.DeadlineExceeded ? InterceptorSettings.TimeoutMaxRetryCount : InterceptorSettings.MaxRetryCount;
}
