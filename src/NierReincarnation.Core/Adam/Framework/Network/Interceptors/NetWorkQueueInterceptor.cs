using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class NetWorkQueueInterceptor : INetworkInterceptor
{
    // Fields
    public static Action TryClearNetWorkQueue;

    private readonly Queue<object> _netWorkQueue = new();
    private readonly int _requestNo;
    private readonly bool _isUserDiffQueued;

    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next) => await next.Invoke(context);

    private void ClearNetWorkQueue() => _netWorkQueue.Clear();

    private void RefreshToken(CommonResponse common)
    {
        if (common is null || string.IsNullOrEmpty(common.Token)) return;

        ApplicationScopeClientContext.Instance.Token.UpdateToken(common.Token);
    }
}
