using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler;

public interface IResponseHandler
{
    public int GetPriority();

    public Task<RetryHandleType> HandleAsync(Api.Api api);
}
