using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler;

namespace NierReincarnation.Core.Dark.Networking.DataSource.Interceptor
{
    // Dark.Networking.DataSource.Interceptor.UserDataUpdateHandler
    class UserDataUpdateHandler : IResponseHandler
    {
        public int GetPriority()
        {
            return 2000;
        }

        public Task<RetryHandleType> HandleAsync(Api api)
        {
            return Task.FromResult(RetryHandleType.None);
        }
    }
}
