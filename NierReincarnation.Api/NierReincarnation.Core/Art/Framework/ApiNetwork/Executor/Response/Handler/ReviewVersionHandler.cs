using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Enum;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler
{
    // Art.Framework.ApiNetwork.Executor.Response.Handler.ReviewVersionHandler
    class ReviewVersionHandler : IResponseHandler
    {
        public int GetPriority()
        {
            return 100;
        }

        public Task<RetryHandleType> HandleAsync(Api.Api api)
        {
            var statusType=api.GetResponseParameter<ResponseParameterBase>().GetCommon().AppVersionStatusType;
            if (statusType == 1)
            {
                ApiSystem.Instance.ServerResolver.SetReviewFlag();
                return Task.FromResult(RetryHandleType.RetryInterrupt);
            }

            return Task.FromResult(RetryHandleType.None);
        }
    }
}
