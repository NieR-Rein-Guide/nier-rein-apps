using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.Collections;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api
{
    // Art.Framework.ApiNetwork.Grpc.Api.UserDiffInfo
    static class UserDiffInfo
    {
        // TODO: Return DiffData based on Response type
        public static MapField<string,DiffData> GetUserDiff(ResponseContext responseContext)
        {
            // Do switch-case type check and get userDiffInfo from GRPC message based on response type
            
            switch (responseContext.ResponseType.FullName)
            {
                case "Art.Framework.ApiNetwork.Grpc.Api.User.GetAndroidArgsResponse":
                    var response = responseContext.GetResponseAs<GetAndroidArgsResponse>().Result;
                    return response.DiffUserData;

                default:
                    return null;
            }
        }
    }
}
