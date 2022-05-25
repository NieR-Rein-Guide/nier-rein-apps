using System;
using System.Collections.Generic;
using Grpc.Core;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc
{
    // Art.Framework.ApiNetwork.Grpc.ChannelProvider
    static class ChannelProvider
    {
        // 0x00
        private static readonly int GRPC_KEEPALIVE_TIME_MS = 2000;
        // 0x04
        private static readonly int GRPC_KEEPALIVE_TIMEOUT_MS = 3000;
        // 0x08
        private static readonly int GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS = 5000;
        // 0x10
        private static ServerResolver resolver;
        // 0x18
        private static Channel _channel;

        public static Channel Channel
        {
            get
            {
                if (_channel != null)
                    return _channel;

                return Initialize();
            }
        }

        public static void SetResolver(ServerResolver resolver)
        {
            ChannelProvider.resolver = resolver;
        }

        private static Channel Initialize()
        {
            if (resolver == null)
                throw new InvalidOperationException("Resolver in ChannelProvider is not setup yet.");

            Setup(resolver.ServerDomain);
            return _channel;
        }

        public static void Setup(string server)
        {
            var channelOptions = new List<ChannelOption>
            {
                new ChannelOption("grpc.keepalive_time_ms", GRPC_KEEPALIVE_TIME_MS),
                new ChannelOption("grpc.keepalive_timeout_ms", GRPC_KEEPALIVE_TIMEOUT_MS),
                new ChannelOption("grpc.http2.min_time_between_pings_ms", GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS)
            };

            var credentials = GetRootCertificateCredentials();

            _channel = new Channel(server, credentials, channelOptions);
        }

        private static ChannelCredentials GetRootCertificateCredentials()
        {
            var roots = Resources.LoadText("roots.pem");

            return roots.Text == string.Empty ? new SslCredentials() : new SslCredentials(roots.Text);
        }
    }
}
