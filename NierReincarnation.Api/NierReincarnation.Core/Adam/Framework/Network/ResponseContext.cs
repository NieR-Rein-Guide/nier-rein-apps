using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public abstract class ResponseContext : IDisposable
    {
        private Dictionary<string, object> _items;

        public abstract Type ResponseType { get; }

        public IDictionary<string, object> Items => _items ??= new Dictionary<string, object>();

        public abstract Metadata GetTrailers();

        public abstract void Dispose();

        public abstract Task<ResponseContext> WaitResponseAsync();

        public Task<T> GetResponseAs<T>()
        {
            return (this as ResponseContext<T>).ResponseAsync;
        }
    }

    internal sealed class ResponseContext<T> : ResponseContext
    {
        private readonly AsyncUnaryCall<T> _responseAction;

        public override Type ResponseType => typeof(T);

        public Task<T> ResponseAsync => _responseAction?.ResponseAsync;

        public ResponseContext(AsyncUnaryCall<T> responseFactory)
        {
            _responseAction = responseFactory;
        }

        public override Metadata GetTrailers()
        {
            return _responseAction?.GetTrailers();
        }

        public override void Dispose()
        {
            _responseAction?.Dispose();
        }

        public override async Task<ResponseContext> WaitResponseAsync()
        {
            await _responseAction.ResponseAsync;
            return this;
        }
    }
}
