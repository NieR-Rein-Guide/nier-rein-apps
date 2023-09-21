using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.EntryPoint;

namespace NierReincarnation.Api.Authentication;

public class BaseAuthenticationProvider : IAuthenticationProvider
{
    private DarkClient DarkClient { get; }

    public BaseAuthenticationProvider()
    {
        DarkClient = new();
    }

    public async Task<AuthenticationUrlResult> GetAuthenticationUrlAsync()
    {
        string uuid = Guid.NewGuid().ToString();
        var backupTokenResponse = await DarkClient.GetBackupTokenAsync(new GetBackupTokenRequest { Uuid = uuid });

        return backupTokenResponse != null
            ? new AuthenticationUrlResult(true, uuid, string.Format(Config.Api.AccountTransferUrl, Config.Api.BridgeGameId, Config.Api.BridgeTypeId, backupTokenResponse.BackupToken))
            : new AuthenticationUrlResult(false);
    }

    public async Task<TransferUserResult> TransferUserAsync(string uuid)
    {
        var transferUserResponse = await DarkClient.TransferUserAsync(new TransferUserRequest { Uuid = uuid });

        return transferUserResponse != null
            ? new TransferUserResult(true, transferUserResponse.UserId, transferUserResponse.Signature)
            : new TransferUserResult(false);
    }
}
