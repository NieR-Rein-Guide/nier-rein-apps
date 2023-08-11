namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Property
{
    public class RequestProperty
    {
        // 0x10
        internal uint RequestId { get; }
        // 0x14
        internal int RetryCount { get; set; }

        // 0x18
        private bool _retryClearRequest;

        internal bool RetryClearRequest
        {
            set => _retryClearRequest = value;
        }
    }
}
