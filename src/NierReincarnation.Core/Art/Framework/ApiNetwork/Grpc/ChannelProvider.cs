using Grpc.Core;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc;

public static class ChannelProvider
{
    private const int GRPC_KEEPALIVE_TIME_MS = 2000;

    private const int GRPC_KEEPALIVE_TIMEOUT_MS = 3000;

    private const int GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS = 5000;

    private static ServerResolver _resolver;

    private static Channel _channel;

    public static Channel Channel => _channel ?? Initialize();

    private static Channel Initialize()
    {
        if (_resolver == null)
        {
            throw new InvalidOperationException("Resolver in ChannelProvider is not setup yet.");
        }

        Setup(_resolver.ServerDomain);
        return _channel;
    }

    public static void Setup(string server)
    {
        List<ChannelOption> channelOptions = new()
        {
            new ChannelOption("grpc.keepalive_time_ms", GRPC_KEEPALIVE_TIME_MS),
            new ChannelOption("grpc.keepalive_timeout_ms", GRPC_KEEPALIVE_TIMEOUT_MS),
            new ChannelOption("grpc.http2.min_time_between_pings_ms", GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS),
            new ChannelOption("grpc.max_receive_message_length", 100 * 1024 * 1024)
        };

        ChannelCredentials credentials = GetRootCertificateCredentials();

        _channel = new Channel(server, credentials, channelOptions);
    }

    public static void SetResolver(ServerResolver resolver)
    {
        _resolver = resolver;
    }

    private static SslCredentials GetRootCertificateCredentials()
    {
        var roots = Resources.LoadText("roots.pem");

        return roots.Text != string.Empty ? new SslCredentials(roots.Text) : new SslCredentials();
    }
}
