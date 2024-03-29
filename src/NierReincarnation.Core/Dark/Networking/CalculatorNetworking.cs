﻿using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.Dark.Kernel;

namespace NierReincarnation.Core.Dark.Networking;

public static class CalculatorNetworking
{
    public class TrList
    {
        public class Tr
        {
            public string ti;
            public object bo;
        }

        public List<Tr> trList;

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

        ServerConfiguration config = new()
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
