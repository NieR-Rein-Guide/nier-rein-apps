using System;
using System.Threading.Tasks;
using Grpc.Core;
using NierReincarnation.Core.Dark.Calculator;

namespace NierReincarnation.Context
{
    public abstract class BaseContext
    {
        public static readonly TimeSpan RateTimeout = TimeSpan.FromMinutes(3);

        public event EventHandler RequestRatioReached;

        public event EventHandler BeforeUnauthenticated;
        public event EventHandler<bool> AfterUnauthenticated;

        protected async Task<TResult> TryRequest<TResult>(Func<Task<TResult>> requestAction)
        {
            while (true)
            {
                var result = await requestAction();
                if (result != null)
                    return result;

                switch (NierReincarnation.LastApiError.StatusCode)
                {
                    // Handle rate limiting
                    case StatusCode.PermissionDenied:
                        // Invoke ratio event
                        OnRequestRatioReached();

                        // Wait out rate limit
                        await Task.Delay(RateTimeout);

                        break;

                    // Handle authentication errors
                    case StatusCode.Unauthenticated:
                        // Invoke event before authentication
                        OnBeforeUnauthenticated();

                        // Re-authorize user
                        await NierReincarnation.AuthorizeUser(CalculatorStateUser.GetUserId());

                        // Re-download user data
                        var isUserSuccess = await NierReincarnation.UpdateUserData();

                        // invoke event after authentication
                        OnAfterUnauthenticated(isUserSuccess);

                        break;
                }
            }
        }

        protected void OnRequestRatioReached()
        {
            RequestRatioReached?.Invoke(this, new EventArgs());
        }

        protected void OnBeforeUnauthenticated()
        {
            BeforeUnauthenticated?.Invoke(this, new EventArgs());
        }

        protected void OnAfterUnauthenticated(bool hasReauthorized)
        {
            AfterUnauthenticated?.Invoke(this, hasReauthorized);
        }
    }
}
