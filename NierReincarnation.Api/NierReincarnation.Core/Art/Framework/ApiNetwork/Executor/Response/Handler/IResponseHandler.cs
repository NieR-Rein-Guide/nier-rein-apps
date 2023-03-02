using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler
{
    // Art.Framework.ApiNetwork.Executor.Response.Handler.IResponseHandler
    interface IResponseHandler
    {
        public int GetPriority();

        public Task<RetryHandleType> HandleAsync(Api.Api api);
    }
}
