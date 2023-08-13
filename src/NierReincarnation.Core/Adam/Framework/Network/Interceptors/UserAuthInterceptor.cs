using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class UserAuthInterceptor : INetworkInterceptor
{
    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        var responseContext = await next(context);

        if (context.MethodPath == InterceptorSettings.AuthRequest)
        {
            // TODO
        }
        else if (context.MethodPath == InterceptorSettings.ServerConfigRequest)
        {
            // TODO
        }

        var response = responseContext.GetCommonResponse();

        RefreshToken(response);

        return responseContext;
    }

    private static void RefreshToken(CommonResponse common)
    {
        if (common is null || string.IsNullOrEmpty(common.Token)) return;

        ApplicationScopeClientContext.Instance.Token.UpdateToken(common.Token);
    }
}
