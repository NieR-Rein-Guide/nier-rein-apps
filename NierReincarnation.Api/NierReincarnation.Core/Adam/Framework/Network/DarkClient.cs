using Grpc.Core;
using NierReincarnation.Core.Adam.Framework.Network.Interceptors;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark;
using System.Security.Cryptography;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient
{
    private const int MAX_INTERCEPT = 10;

    public static Func<string, Task> ClientFatalNetWorkError;

    public static Action<string, object> OnVerifyToken;

    public Action<DarkNetworkError> AfterErrorAction;

    public Action<RpcException> OnErrorAction;

    private readonly Channel Channel;

    private readonly CancellationToken CancellationToken;

    private readonly TimeSpan Deadline;

    private readonly INetworkInterceptor[] Interceptors;

    private static readonly INetworkInterceptor[] defaultInterceptors =
    {
        //new NetWorkQueueInterceptor(),
        new ErrorHandlingInterceptor(),
        new SetCommonHeaderInterceptor(),
        //new ReviewVersionInterceptor(),
        new UserDiffUpdateInterceptor(),
        new UserAuthInterceptor()
    };

    private static readonly string[] kIgnoreRequestLogOutputPathList = Array.Empty<string>();
    private static readonly string[] kIgnoreResponseLogOutputPathList = new[] { "DataService/GetUserDataAsync" };

    public DarkClient(CancellationToken cancellationToken = default, TimeSpan? timeout = default, INetworkInterceptor[]? interceptors = null)
    {
        Channel = ChannelProvider.Channel;
        CancellationToken = cancellationToken;

        if (timeout.HasValue)
        {
            Deadline = timeout.Value;
        }
        else
        {
            var ms = DatabaseDefine.Master != null
                ? Dark.Networking.Config.GetGrpcTimeoutMilliseconds()
                : 10000;

            Deadline = TimeSpan.FromMilliseconds(ms);
        }

        Interceptors = interceptors == null ? defaultInterceptors : defaultInterceptors.Concat(interceptors).ToArray();
    }

    #region Invokation methods

    private async Task<TResponse> InvokeAsync<TResponse, TRequest>(string path, TRequest request, Func<RequestContext, ResponseContext> requestMethod)
    {
        var reqContext = new RequestContext(this, path, request, Channel, new Metadata(), Deadline, CancellationToken, Interceptors, requestMethod, typeof(TResponse), OnErrorAction, OnVerifyToken);
        var resContext = await InvokeWithInterceptor(reqContext);
        return resContext != null ? await resContext.GetResponseAs<TResponse>() : default;
    }

    private static Task<ResponseContext> InvokeWithInterceptor(RequestContext context) => InvokeRecursive(context);

    private static Task<ResponseContext> InvokeRecursive(RequestContext context, int index = -1)
    {
        if (context.Interceptors.Length - 1 == index)
        {
            return context.RequestMethod?.Invoke(context).WaitResponseAsync();
        }

        if (context.Interceptors.Length <= index + 1)
        {
            throw new IndexOutOfRangeException();
        }

        var interceptor = context.Interceptors[index + 1];
        return interceptor.SendAsync(context, _ => InvokeRecursive(context, index + 1));
    }

    #endregion Invokation methods

    public static string CreateVerifierToken()
    {
        byte[] hash = SHA1.HashData(Encoding.UTF8.GetBytes($"{ApplicationScopeClientContext.Instance.User.UserId}{ApplicationScopeClientContext.Instance.Token.Value}"));
        return Convert.ToHexString(hash).ToLower();
    }

    // CUSTOM: A custom method to inject de-/encryption of gRPC messages through PayloadCallInvoker PayloadCallInvoker delegates are set in Dark.StateMachine.HandleNet.Initialize
    private static PayloadCallInvoker GetCallInvoker(Channel channel) => new(channel);
}
