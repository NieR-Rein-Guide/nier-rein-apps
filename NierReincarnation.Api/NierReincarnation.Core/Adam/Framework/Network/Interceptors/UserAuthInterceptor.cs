using System;
using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Response;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors
{
    // Adam.Framework.Network.Interceptors.UserAuthInterceptor
    class UserAuthInterceptor : INetworkInterceptor
    {
        public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
        {
            var responseContext = await next(context);

            // TODO: Implement remaining GRPC responses
            if (context.MethodPath == InterceptorSettings.AuthRequest)
            {
                ;
                //    var authUserResponse = await responseContext.GetResponseAs<AuthUserResponse>();
                //    var authInfo = ApplicationScopeClientContext.Instance.Auth;

                //    var userAuthData = new UserAuthData
                //    {
                //        SessionKey = authUserResponse.SessionKey,
                //        ExpireDatetime = authUserResponse.0x18.0x10
                //    };
                //    authInfo.UpdateSession(userAuthData);

                //    ApplicationScopeClientContext.Instance.User.UpdateSignature(authUserResponse.0x20);

                //    if (context.Channel.Target == InterceptorSettings.ServerConfigRequest)
                //    {
                //        var registerUserResponse = await responseContext.GetResponseAs<RegisterUserResponse>();
                //        ApplicationScopeClientContext.Instance.User.SetUserData(new UserRegisterData
                //        {
                //            UserId = registerUserResponse.0x10,
                //            Signature = registerUserResponse.0x18,
                //            UuId = ApplicationScopeClientContext.Instance.User.Uuid
                //        });
                //    }

                //    RefreshToken(responseContext.GetCommonResponse());
            }
            else if (context.MethodPath == InterceptorSettings.ServerConfigRequest)
            {
                ;
                //    var authUserResponse = await responseContext.GetResponseAs<RegisterUserResponse>();
            }

            var response = responseContext.GetCommonResponse();
            RefreshToken(response);

            return responseContext;
        }

        private void RefreshToken(CommonResponse response)
        {
            if (string.IsNullOrEmpty(response.Token))
                return;

            ApplicationScopeClientContext.Instance.Token.UpdateToken(response.Token);
        }
    }
}
