namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class ReviewVersionInterceptor : INetworkInterceptor
{
    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next) => await next.Invoke(context);

    // TODO
    public async Task<bool> IsAppVersionInReview(int appVersionStatusType, RequestContext context) => false;
}
