using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace NierReincarnation.Context
{
    public abstract class BaseContext
    {
        public static readonly TimeSpan RateTimeout = TimeSpan.FromMinutes(3);

        public event EventHandler RequestRatioReached;

        protected async Task<TResult> TryRequest<TResult>(Func<Task<TResult>> requestAction)
        {
            while (true)
            {
                var result = await requestAction();
                if (result != null)
                    return result;

                // Handle rate limiting
                if (NierReincarnation.LastApiError.StatusCode == StatusCode.PermissionDenied)
                {
                    // Invoke ratio event
                    OnRequestRatioReached();

                    // Wait out rate limit
                    await Task.Delay(RateTimeout);
                }
            }
        }

        protected void OnRequestRatioReached()
        {
            RequestRatioReached?.Invoke(this, new EventArgs());
        }
    }
}
