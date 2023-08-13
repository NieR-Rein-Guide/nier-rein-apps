using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class UserDiffUpdateInterceptor : INetworkInterceptor
{
    public static Action<long> SetGameTimeNow;

    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        var responseContext = await next(context);

        var commonResponse = responseContext.GetCommonResponse();
        SetGameTimeNow?.Invoke(commonResponse.ResponseDatetime);

        // TODO: Update user diff
        var userDiff = UserDiffInfo.GetUserDiff(responseContext);

        return responseContext;
    }
}
