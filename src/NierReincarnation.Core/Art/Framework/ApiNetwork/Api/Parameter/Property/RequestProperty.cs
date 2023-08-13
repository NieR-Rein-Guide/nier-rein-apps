namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property;

public class RequestProperty
{
    internal uint RequestId { get; }

    internal int RetryCount { get; set; }

    private bool _retryClearRequest;

    internal bool RetryClearRequest
    {
        set => _retryClearRequest = value;
    }
}
