using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using Newtonsoft.Json;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api;
using NierReincarnation.Core.Dark;

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
            SetGameTimeNow?.Invoke(commonResponse.ResponseDatetime);

            var userDiff = UserDiffInfo.GetUserDiff(responseContext);

            // CUSTOM: Update user diff data in User Database
            if (userDiff != null && userDiff.Count > 0)
            {
                foreach (var userData in userDiff)
                {
                    DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));
                    DatabaseDefine.User.Delete(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.DeleteKeysJson));
                }
            }

            // Update specially on registering a user
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
