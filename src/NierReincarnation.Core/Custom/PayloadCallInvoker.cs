using Google.Protobuf;
using Grpc.Core;

namespace NierReincarnation.Core.Custom;

public class PayloadCallInvoker : DefaultCallInvoker
{
    public static Func<byte[], byte[]> Encrypt;
    public static Func<byte[], byte[]> Decrypt;

    private readonly Channel channel;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultCallInvoker"/> class.
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

    private static Marshaller<TRequest> CreateRequestMarshaller<TRequest>(Marshaller<TRequest> req) where TRequest : class
    {
        return new Marshaller<TRequest>(
            (request, context) => Serialize(request as IMessage, context),
            context => Deserialize(context, req));
    }

    private Marshaller<TResponse> CreateResponseMarshaller<TResponse>(Marshaller<TResponse> res)
    {
        return new Marshaller<TResponse>(
            (request, context) => Serialize(request as IMessage, context),
            context => Deserialize(context, res));
    }

    private static void Serialize(IMessage message, SerializationContext context)
    {
        byte[] payload = message.ToByteArray();
        payload = Encrypt?.Invoke(payload) ?? payload;

        context.Complete(payload);
    }

    private static T Deserialize<T>(DeserializationContext context, Marshaller<T> res)
    {
        byte[] payload = context.PayloadAsNewBuffer();
        payload = Decrypt?.Invoke(payload) ?? payload;

        return res.ContextualDeserializer(new PayloadDeserializationContext(payload));
    }
}
