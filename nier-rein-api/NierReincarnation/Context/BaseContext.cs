using System;
using System.Threading.Tasks;
using Grpc.Core;
using NierReincarnation.Core.Dark.Calculator;

namespace NierReincarnation.Context
{
    public abstract class BaseContext
    {
        private static readonly TimeSpan RateTimeout = TimeSpan.FromMinutes(3);

        public event Action<TimeSpan> RequestRatioReached;

        public event Action BeforeUnauthenticated;
        public event Action<bool> AfterUnauthenticated;

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
                        OnRequestRatioReached(RateTimeout);

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
                        await NierReincarnation.UpdateUserData();

                        // TODO: Get indicator if request should be cancelled after re-authorization
                        // TODO: Either remove bool in event or properly set it by AuthorizeUser result, instead of UserData update
                        // Invoke event after authentication
                        OnAfterUnauthenticated(true);

                        break;
                }
            }
        }

        protected void OnRequestRatioReached(TimeSpan timeout)
        {
            RequestRatioReached?.Invoke(timeout);
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
}
