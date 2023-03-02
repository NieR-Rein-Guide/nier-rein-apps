using System;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Executor.Response.Handler;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork
{
    // Art.Framework.ApiNetwork.ApiSystem
    sealed class ApiSystem
    {
        //private readonly JobController _jobController; // 0x10
        private readonly Lazy<Parameter.Parameter> _parameter; // 0x18

        // 0x00
        public static ApiSystem Instance { get; } = new ApiSystem();

        public Parameter.Parameter Parameter => _parameter.Value;

        // 0x20
        public ServerResolver ServerResolver { get; }

        // 0x28
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
}
