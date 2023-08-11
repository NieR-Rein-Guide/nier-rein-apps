using System;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Dark.Networking.DataSource.DarkServer.Grpc;

// Dark.Networking.DataSource.DarkServer.Grpc.UserAuth
class UserAuth : DarkServerAPI<AuthUserRequest, AuthUserResponse>
{
    protected override Func<AuthUserRequest, Task<AuthUserResponse>> CreateRequester()
    {
        return new DarkClient().UserService.AuthAsync;
    }
}
