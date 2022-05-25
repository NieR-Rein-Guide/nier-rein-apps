using System;
using System.Buffers;
using Google.Protobuf;
using Grpc.Core;

namespace NierReincarnation.Core.Custom
{
    /// <summary>
    /// Invokes client RPCs using <see cref="Calls"/>.
    /// </summary>
    class PayloadCallInvoker : DefaultCallInvoker
    {
        public static Func<byte[], byte[]> Encrypt;
        public static Func<byte[], byte[]> Decrypt;

        readonly Channel channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grpc.Core.DefaultCallInvoker"/> class.
        /// </summary>
        /// <param name="channel">Channel to use.</param>
        public PayloadCallInvoker(Channel channel) : base(channel)
        {
            this.channel = channel;
        }

        protected override CallInvocationDetails<TRequest, TResponse> CreateCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options)
        {
            return new CallInvocationDetails<TRequest, TResponse>(channel, method.FullName, host, CreateRequestMarshaller(method.RequestMarshaller), CreateResponseMarshaller(method.ResponseMarshaller), options);
        }

        private Marshaller<TRequest> CreateRequestMarshaller<TRequest>(Marshaller<TRequest> req) where TRequest : class
        {
            // Since there is no possibility to change the context de-/serializer otherwise, we reset it to our own,
            // to intercept setting the payload and make modifications possible
            // HINT: This assumes the default auto-generated __Helper_SerializeMessage and __Helper_DeserializeMessage
            return new Marshaller<TRequest>(
                (request, context) =>
                    Serialize(request as IMessage, context),
                context =>
                    Deserialize(context, req));
        }

        private Marshaller<TResponse> CreateResponseMarshaller<TResponse>(Marshaller<TResponse> res)
        {
            // Since there is no possibility to change the context de-/serializer otherwise, we reset it to our own,
            // to intercept setting the payload and make modifications possible
            // HINT: This assumes the default auto-generated __Helper_SerializeMessage and __Helper_DeserializeMessage
            return new Marshaller<TResponse>(
                (request, context) =>
                    Serialize(request as IMessage, context),
                context =>
                    Deserialize(context, res));
        }

        private void Serialize(IMessage message, SerializationContext context)
        {
            var payload = message.ToByteArray();
            payload = Encrypt?.Invoke(payload) ?? payload;

            context.Complete(payload);
        }

        private T Deserialize<T>(DeserializationContext context, Marshaller<T> res)
        {
            var payload = context.PayloadAsNewBuffer();
            payload = Decrypt?.Invoke(payload) ?? payload;

            return res.ContextualDeserializer(new PayloadDeserializationContext(payload));
        }
    }

    class PayloadDeserializationContext : DeserializationContext
    {
        byte[] payload;

        public override int PayloadLength { get; }

        public PayloadDeserializationContext(byte[] payload)
        {
            this.payload = payload;
            PayloadLength = payload.Length;
        }

        public override byte[] PayloadAsNewBuffer()
        {
            return payload;
        }

        public override ReadOnlySequence<byte> PayloadAsReadOnlySequence()
        {
            return new ReadOnlySequence<byte>(payload);
        }
    }
}
