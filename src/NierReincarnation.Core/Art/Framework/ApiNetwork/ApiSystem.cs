using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork;

public sealed class ApiSystem
{
    private static ApiSystem _instance;
    private readonly Lazy<Parameter.Parameter> _parameter;

    public static ApiSystem Instance
    {
        get
        {
            _instance ??= new();
            return _instance;
        }
    }

    public Parameter.Parameter Parameter => _parameter.Value;

    public ServerResolver ServerResolver { get; }

    public IDataStore DataStore { get; }

    public ApiSystem()
    {
        ServerResolver = new ServerResolver();
        _parameter = new Lazy<Parameter.Parameter>(() => new Parameter.Parameter());

        DataStore = Data.DataStore.Default;

        RegisterResponseHandler(new TokenRefreshHandler());
        RegisterResponseHandler(new ReviewVersionHandler());
    }

    public void RegisterResponseHandler(IResponseHandler handler)
    {
        // TODO: Depends on JobController; Necessary?
    }
}
