using System.Collections.Generic;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using Newtonsoft.Json;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.Dark.Kernel;

namespace NierReincarnation.Core.Dark.Networking
{
    // Dark.Networking.CalculatorNetworking
    static class CalculatorNetworking
    {
        public class TrList
        {
            public class Tr
            {
                public string ti; // 0x10
                public object bo; // 0x18
            }

            public List<Tr> trList; // 0x10

            public TrList()
            {
                trList = new List<Tr>();
            }

            public void AddTrJson(string tag, object report)
            {
                trList.Add(new Tr
                {
                    ti = tag,
                    bo = report
                });
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(trList);
            }
        }

        public static void InitializeApiClient(int masterVersion, string serverAddress, int serverPort)
        {
            ApplicationApi.SetReviewServerInfo(serverAddress, serverPort);
            ApplicationScopeClientContext.Instance.MasterData.UpdateMasterDataVersion(masterVersion);

            var config = new ServerConfiguration
            {
                Server = $"{serverAddress}:{serverPort}",
                ReviewServer = $"{serverAddress}:{serverPort}"
            };
            ApplicationScopeClientContext.Instance.ServerResolver.SetConfiguration(config);
        }

        public static AuthUserRequest GetAuthUserRequestParameter()
        {
            KernelState.GetUserState(out _);

            return new AuthUserRequest
            {
                Uuid = ApplicationScopeClientContext.Instance.User.Uuid,
                Signature = ApplicationScopeClientContext.Instance.User.Signature ?? string.Empty,
                AdvertisingId = ApplicationScopeClientContext.Instance.User.AdvertisingId ?? string.Empty,
                IsTrackingEnabled = ApplicationScopeClientContext.Instance.User.IsTrackingEnabled
            };
        }

        public static void SetupAuthUpdateUserState(long userId, string signature)
        {
            KernelState.GetUserState(out var userState);

            var stateUser = userState.FieldStateUser();
            stateUser.Id = userId;
            stateUser.Signature = signature;
        }
    }
}
