using System;
using System.Threading.Tasks;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Exception;

namespace NierReincarnation.Core.Dark.Networking.DataSource;

// Dark.Networking.DataSource.DarkServerAPI
abstract class DarkServerAPI<TRequest, TResponse> : IDataSource
{
    public delegate void HandleSuccess(TResponse response);
    public delegate void HandleError(ClientError error);

    public event HandleSuccess OnSuccess;
    public event HandleError OnFailed;

    public async Task RequestAsync(object request, bool isInterception)
    {
        // Unknown usage of isInterception
        try
        {
            var requester = CreateRequester();
            if (requester == null)
                return;

            var response = await requester.Invoke((TRequest)request);
            OnSuccessRequest(response);
        }
        catch
        {
            // TODO: Implement on error invokation
            //OnFatalErrorRequest(new ApiFatalErrorException());
        }
    }

    protected abstract Func<TRequest, Task<TResponse>> CreateRequester();

    private void OnSuccessRequest(TResponse response)
    {
        OnSuccess?.Invoke(response);
    }

    private void OnErrorRequest(ApiErrorException exception)
    {
        OnFailed?.Invoke(ConvertClientError(exception));
    }

    private void OnFatalErrorRequest(ApiFatalErrorException exception)
    {
        OnFailed?.Invoke(ConvertClientError(exception));
    }

    private ClientError ConvertClientError(ApiErrorException exception)
    {
        return new ClientError { ScreenTransitionType = exception.ScreenTransitionType };
    }
}
