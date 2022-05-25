using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler
{
    class TokenRefreshHandler : IResponseHandler
    {
        public int GetPriority()
        {
            return 1000;
        }

        public Task<RetryHandleType> HandleAsync(Api.Api api)
        {
            var token = api.GetResponseParameter<ResponseParameterBase>().GetCommon().token;
            if (!string.IsNullOrEmpty(token))
                ApiSystem.Instance.Parameter.Token.UpdateToken(token);

            return Task.FromResult(RetryHandleType.None);
        }
    }
}
