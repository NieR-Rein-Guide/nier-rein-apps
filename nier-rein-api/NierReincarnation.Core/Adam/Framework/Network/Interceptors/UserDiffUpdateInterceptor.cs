using System;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors
{
    // Adam.Framework.Network.Interceptors.UserDiffUpdateInterceptor
    // TODO: Implement fully
    class UserDiffUpdateInterceptor : INetworkInterceptor
    {
        public static Action<long> SetGameTimeNow; // 0x0

        public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
        {
            var responseContext = await next(context);

            var commonResponse = responseContext.GetCommonResponse();
            SetGameTimeNow?.Invoke(commonResponse.responseDatetime);

            var userDiff = UserDiffInfo.GetUserDiff(responseContext);
            if (userDiff != null && userDiff.Count > 0 && responseContext.ResponseType.Name == nameof(RegisterUserResponse))
            {
                // HINT: Looping through MapField
                //ApplicationScopeClientContext.Instance.User.UserId
                //DatabaseDefine.DarkUserMemoryDatabase.0x228.0x10.0x18
            }

            return responseContext;
        }
    }
}
