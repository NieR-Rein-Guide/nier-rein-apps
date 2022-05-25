using System;
using System.Threading;
using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    // Adam.Framework.Network.RequestContext
    public class RequestContext
    {
        private readonly DarkClient _client;
        private readonly Type _responseType;
        private readonly TimeSpan _timeOut; // 0x38

        // 0x18
        public string MethodPath { get; }
        // 0x20
        public object Request { get; }
        // 0x28
        public Channel Channel { get; private set; }
        // 0x30
        public Metadata Headers { get; }
        public DateTime? Deadline => DateTime.UtcNow.Add(_timeOut);
        public TimeSpan TimeOut => _timeOut;
        public CancellationToken CancellationToken { get; }

        public Action<RpcException> OnError { get; }
        public Action<string, object> OnVerifyToken { get; }

        public int RequestNo { get; set; } = -1;
        // 0x68
        public INetworkInterceptor[] Interceptors { get; }
        // 0x70
        public Func<RequestContext, ResponseContext> RequestMethod { get; }

        internal RequestContext(DarkClient client, string methodPath, object request, Channel channel, Metadata headers, TimeSpan timeOut, CancellationToken cancellationToken, INetworkInterceptor[] interceptors, Func<RequestContext, ResponseContext> requestMethod,
            Type responseContextType, Action<RpcException> onError, Action<string, object> onVerifyToken)
        {
            _client = client;
            _responseType = responseContextType;
            _timeOut = timeOut;

            MethodPath = methodPath;
            Request = request;
            Channel = channel;
            Headers = headers;
            CancellationToken = cancellationToken;

            OnError = onError;
            OnVerifyToken = onVerifyToken;

            Interceptors = interceptors;
            RequestMethod = requestMethod;
        }

        public void UpdateChannel(Channel channel)
        {
            Channel = channel;
        }

        public void UpdateVerifyToken()
        {
            OnVerifyToken?.Invoke(MethodPath, Request);
        }
    }
}
