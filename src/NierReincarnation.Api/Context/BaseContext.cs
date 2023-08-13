using Grpc.Core;
using NierReincarnation.Context.Support;

namespace NierReincarnation.Context;

public abstract class BaseContext
{
    public event Func<RpcException, Task> GeneralError;

    public event Action BeforeUnauthenticated;

    public event Action<bool> AfterUnauthenticated;

    protected async Task<TResult> TryRequest<TResult>(Func<Task<TResult>> requestAction, bool handleGeneralError = true)
    {
        while (true)
        {
            var result = await requestAction();
            if (result != null)
            {
                NierReincarnationApp.ClearNetworkError();
                return result;
            }

            switch (NierReincarnationApp.LastApiError.StatusCode)
            {
                // Pass invalid result back to caller
                default:
                    if (handleGeneralError)
                        await OnGeneralError(NierReincarnationApp.LastApiError);

                    NierReincarnationApp.ClearNetworkError();

                    // Re-authorize user after error
                    await NierReincarnationApp.AuthorizeUserAsync(CalculatorStateUser.GetUserId());

                    return default;

                // Handle rate limiting
                case StatusCode.PermissionDenied:
                    // Start cooldown timer
                    CooldownTimer.Start();

                    // Wait out rate limit
                    await Task.Delay(CooldownTimer.CurrentCooldown);

                    break;

                // Handle authentication errors
                case StatusCode.Unauthenticated:
                    // Invoke event before authentication
                    OnBeforeUnauthenticated();

                    // Re-authorize user
                    await NierReincarnationApp.AuthorizeUserAsync(CalculatorStateUser.GetUserId());

                    // Re-download user data
                    //await NierReincarnation.UpdateUserData();

                    // TODO: Get indicator if request should be cancelled after re-authorization
                    // TODO: Either remove bool in event or properly set it by AuthorizeUser result, instead of UserData update Invoke event after authentication
                    OnAfterUnauthenticated(true);

                    break;
            }

            NierReincarnationApp.ClearNetworkError();
        }
    }

    protected async Task OnGeneralError(RpcException error)
    {
        if (GeneralError != null)
            await GeneralError(error);
    }

    protected void OnBeforeUnauthenticated()
    {
        BeforeUnauthenticated?.Invoke();
    }

    protected void OnAfterUnauthenticated(bool hasReauthorized)
    {
        AfterUnauthenticated?.Invoke(hasReauthorized);
    }
}
