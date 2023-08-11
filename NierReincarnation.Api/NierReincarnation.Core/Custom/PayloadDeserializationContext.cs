using Grpc.Core;
using System.Buffers;

namespace NierReincarnation.Core.Custom;

internal class PayloadDeserializationContext : DeserializationContext
{
    private readonly byte[] Payload;

    public override int PayloadLength { get; }

    public PayloadDeserializationContext(byte[] payload)
    {
        Payload = payload;
        PayloadLength = payload.Length;
    }

    public override byte[] PayloadAsNewBuffer() => Payload;

    public override ReadOnlySequence<byte> PayloadAsReadOnlySequence() => new ReadOnlySequence<byte>(Payload);
}
