using Grpc.Core;

namespace NierReincarnation.Core.Adam.Framework.Network;

public abstract class ResponseContext : IDisposable
{
    private Dictionary<string, object> _items;

    public abstract Type ResponseType { get; }

    public IDictionary<string, object> Items => _items ??= new Dictionary<string, object>();

    public abstract Metadata GetTrailers();

    public abstract void Dispose();

    public abstract Task<ResponseContext> WaitResponseAsync();

    public Task<T> GetResponseAs<T>() => ((ResponseContext<T>)this).ResponseAsync;

    protected ResponseContext()
    {
        _items = new Dictionary<string, object>();
    }
}

internal sealed class ResponseContext<T> : ResponseContext
{
    private readonly AsyncUnaryCall<T> _call;

    public override Type ResponseType => typeof(T);

    public Task<T> ResponseAsync => _call?.ResponseAsync;

    public ResponseContext(AsyncUnaryCall<T> responseFactory)
    {
        _call = responseFactory;
    }

    public override Metadata GetTrailers() => _call?.GetTrailers();

    public override void Dispose() => _call?.Dispose();

    public override async Task<ResponseContext> WaitResponseAsync()
    {
        await _call.ResponseAsync;
        return this;
    }
}
