using NierReincarnation.Core.Art.Framework.ApiNetwork.Api;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler;

namespace NierReincarnation.Core.Dark.Networking.DataSource.Interceptor;

public class UserDataUpdateHandler : IResponseHandler
{
    public int GetPriority() => 2000;

    public Task<RetryHandleType> HandleAsync(Api api)
    {
        return Task.FromResult(RetryHandleType.None);
    }
}
