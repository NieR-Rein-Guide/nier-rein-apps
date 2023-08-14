namespace NierReincarnation.Api.Authentication;

public interface IAuthenticationProvider
{
    Task<AuthenticationUrlResult> GetAuthenticationUrlAsync();

    Task<TransferUserResult> TransferUserAsync(string uuid);
}
