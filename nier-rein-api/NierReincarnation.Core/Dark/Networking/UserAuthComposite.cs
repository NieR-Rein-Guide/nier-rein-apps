using System;
using System.Threading;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Art.Framework.ApiNetwork;
using NierReincarnation.Core.Dark.Networking.DataSource;
using NierReincarnation.Core.Dark.Networking.DataSource.DarkServer.Grpc;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.Networking
{
    // Dark.Networking.UserAuthComposite
    class UserAuthComposite
    {
        // Fields
        private static UserAuthComposite _userAuthComposite; // 0x0

        // Methods

        public static Task UserAuth(CancellationToken cancellationToken)
        {
            _userAuthComposite ??= new UserAuthComposite();

            return _userAuthComposite.DoAuth(cancellationToken);
        }

        private async Task DoAuth(CancellationToken cancellationToken)
        {
            var authUser = CalculatorNetworking.GetAuthUserRequestParameter();
            var argsRequest = new GetAndroidArgsRequest
            {
                Uuid = authUser.Uuid,
                Signature = authUser.Signature,
                PackageName = Application.Identifier
            };

            // Update tr objects
            var response = await new DarkClient().UserService.GetAndroidArgsAsync(argsRequest);
            // var liliumObject = await SafetyNet.Lilium(response.ApiKey,response.Nonce)

            var trList = new CalculatorNetworking.TrList();
            trList.AddTrJson("lr", null);   // Add liliumObject
            trList.AddTrJson("ijb", DeviceUtil.DeviceUtil.GetIjb());
            trList.AddTrJson("hig", DeviceUtil.DeviceUtil.GetHig());
            trList.AddTrJson("acs", DeviceUtil.DeviceUtil.GetAcs());
            trList.AddTrJson("per", DeviceUtil.DeviceUtil.GetPer());
            trList.AddTrJson("imu", DeviceUtil.DeviceUtil.GetImu());
            trList.AddTrJson("ir", DeviceUtil.DeviceUtil.GetIr());
            trList.AddTrJson("ia", DeviceUtil.DeviceUtil.GetIda());
            trList.AddTrJson("ms", DeviceUtil.DeviceUtil.GetMsl());
            trList.AddTrJson("ics", DeviceUtil.DeviceUtil.GetIcs());

            authUser.Tr = trList.ToJson();

            // Update advertisingId
            var activePlayer = PlayerPreference.Instance.ActivePlayer;
            await activePlayer.UpdateAdvertisingIdAsync();
            ApplicationScopeClientContext.Instance.User.UpdateAdvertisingId(activePlayer.AdvertisingId, activePlayer.IsTrackingEnabled);

            authUser.AdvertisingId = activePlayer.AdvertisingId;
            authUser.IsTrackingEnabled = activePlayer.IsTrackingEnabled;

            var action = new Action<AuthUserResponse>(res =>
            {
                ApiSystem.Instance.Parameter.UpdateSession(res.SessionKey);
                var preference = new ContextPreference
                {
                    SessionKey = res.SessionKey,
                    SessionExpire = res.ExpireDatetime.Seconds
                };

                ApplicationScopeClientContext.Instance.Auth = new ApplicationScopeClientContext.AuthInfo(preference);

                var masterDataVersion = ApplicationScopeClientContext.Instance.MasterData;
                ApplicationScopeClientContext.Instance.MasterData = new ApplicationScopeClientContext.MasterDataVersionInfo(preference);
                ApplicationScopeClientContext.Instance.MasterData.UpdateMasterDataHash(masterDataVersion.MasterDataHash);

                ReplaceUserData(res.UserId, res.Signature);
            });

            await RequestApiAsync<UserAuth, AuthUserRequest, AuthUserResponse>(DataSourceType.UserAuth, authUser, action, cancellationToken);
        }

        private void ReplaceUserData(long userId, string signature)
        {
            var activePlayer = PlayerPreference.Instance.ActivePlayer;
            var uuid = activePlayer.Uuid;

            var playerRegistration = new PlayerRegistration(uuid)
            {
                Signature = signature,
                UserId = userId,
                ServerAddressAndPort = activePlayer.ServerAddressAndPort,
                Uuid = activePlayer.Uuid,
                TerminalId = activePlayer.TerminalId,
                AdvertisingId = activePlayer.AdvertisingId,
                IsTrackingEnabled = activePlayer.IsTrackingEnabled,

                // CUSTOM: Keep those information with an update, to use it in operations
                PlayerId = activePlayer.PlayerId,
                MomTappedCount = activePlayer.MomTappedCount
            };

            PlayerPreference.Instance.ActivePlayer = playerRegistration;

            ApplicationScopeClientContext.Instance.User = new ApplicationScopeClientContext.UserInfo(playerRegistration);
            CalculatorNetworking.SetupAuthUpdateUserState(userId, signature);
        }

        private Task RequestApiAsync<TSource, TRequest, TResponse>(DataSourceType dataSourceType,
            TRequest request, Action<TResponse> onSuccess, CancellationToken cancellationToken)
        where TSource : DarkServerAPI<TRequest, TResponse>, new()
        {
            var api = new TSource();
            api.OnSuccess += response => onSuccess(response);

            return api.RequestAsync(request, false);
        }
    }
}
