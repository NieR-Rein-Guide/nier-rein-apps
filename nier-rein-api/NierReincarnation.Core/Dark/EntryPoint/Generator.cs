using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Art.Framework.ApiNetwork;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc;
using NierReincarnation.Core.Art.Library.Masterdata.Download;
using NierReincarnation.Core.Dark.Networking.DataSource.Interceptor;

namespace NierReincarnation.Core.Dark.EntryPoint
{
    class Generator
    {
        public static void SetupApiSystem()
        {
            ChannelProvider.SetResolver(ApplicationScopeClientContext.Instance.ServerResolver);

            MasterDataDownloader.MasterDataVersionGetter = () => ApplicationScopeClientContext.Instance.MasterData.MasterDataVersion;
            MasterDataDownloader.MasterDataVersionSetter = v => ApplicationScopeClientContext.Instance.MasterData.UpdateMasterDataVersion(v);

            ApiSystem.Instance.RegisterResponseHandler(new UserDataUpdateHandler());
        }
    }
}
