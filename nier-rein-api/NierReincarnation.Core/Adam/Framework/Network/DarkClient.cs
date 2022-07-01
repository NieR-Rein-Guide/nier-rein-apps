using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Battle;
using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;
using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;
using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using Art.Framework.ApiNetwork.Grpc.Api.Explore;
using Art.Framework.ApiNetwork.Grpc.Api.Gacha;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NierReincarnation.Core.Adam.Framework.Network.Interceptors;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    // Adam.Framework.Network.DarkClient
    public class DarkClient : IBattleService, IConsumableItemService, IDataService, IGachaService, IUserService, IExploreService, IQuestService, IBigHuntService, IDeckService
    {
        // 0x00
        private static readonly int MAX_INTERCEPT = 10;
        // 0x08
        public static Func<string, Task> ClientFatalNetWorkError;
        // 0x10
        public static Action<string, object> OnVerifyToken;

        // 0x18
        private static readonly INetworkInterceptor[] defaultInterceptors = {
            //new NetworkQueueInterceptor(),
            new ErrorHandlingInterceptor(),
            new SetCommonHeaderInterceptor(),
            //new ReviewVersionInterceptor(),
            new UserDiffUpdateInterceptor(),
            new UserAuthInterceptor()
        };

        // 0x10
        public Action<DarkNetworkError> AfterErrorAction;
        // 0x18
        public Action<RpcException> OnErrorAction;
        // 0x20
        private Channel channel;
        // 0x28
        private CancellationToken cancellationToken;
        // 0x30
        private TimeSpan deadline;
        // 0x38
        private INetworkInterceptor[] interceptors;

        public IBattleService BattleService => this;

        public IConsumableItemService ConsumableItemService => this;

        public IDataService DataService => this;

        public IGachaService GachaService => this;

        public IQuestService QuestService => this;

        public IBigHuntService BigHuntService => this;

        public IUserService UserService => this;

        public IDeckService DeckService => this;

        // Done
        public DarkClient(CancellationToken cancellationToken = default, TimeSpan? timeout = default, INetworkInterceptor[] interceptors = null)
        {
            channel = ChannelProvider.Channel;
            this.cancellationToken = cancellationToken;

            // Set deadline
            var ms = DatabaseDefine.Master == null ?
                10000 :
                Dark.Networking.Config.GetGrpcTimeoutMilliseconds();

            deadline = new TimeSpan(0, 0, 0, 0, ms);

            this.interceptors = interceptors == null ? defaultInterceptors : defaultInterceptors.Concat(interceptors).ToArray();
        }

        #region IBattleService

        public Task<StartWaveResponse> StartWaveAsync(StartWaveRequest request)
        {
            var path = "BattleService/StartWaveAsync";
            return InvokeAsync<StartWaveResponse, StartWaveRequest>(path, request,
                ctx =>
                    new ResponseContext<StartWaveResponse>(new BattleService.BattleServiceClient(GetCallInvoker(ctx.Channel)).StartWaveAsync((StartWaveRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<FinishWaveResponse> FinishWaveAsync(FinishWaveRequest request)
        {
            var path = "BattleService/FinishWaveAsync";
            return InvokeAsync<FinishWaveResponse, FinishWaveRequest>(path, request,
                ctx =>
                    new ResponseContext<FinishWaveResponse>(new BattleService.BattleServiceClient(GetCallInvoker(ctx.Channel)).FinishWaveAsync((FinishWaveRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IConsumableItemService

        public Task<UseEffectItemResponse> UseEffectItemAsync(UseEffectItemRequest request)
        {
            var path = "ConsumableItemService/UseEffectItemAsync";
            return InvokeAsync<UseEffectItemResponse, UseEffectItemRequest>(path, request,
                ctx =>
                    new ResponseContext<UseEffectItemResponse>(new ConsumableItemService.ConsumableItemServiceClient(GetCallInvoker(ctx.Channel)).UseEffectItemAsync((UseEffectItemRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IDataService

        public Task<MasterDataGetLatestVersionResponse> GetLatestMasterDataVersionAsync(Empty request)
        {
            var path = "DataService/GetLatestMasterDataVersionAsync";
            return InvokeAsync<MasterDataGetLatestVersionResponse, Empty>(path, request,
                ctx =>
                    new ResponseContext<MasterDataGetLatestVersionResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetLatestMasterDataVersionAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<UserDataGetNameResponse> GetUserDataNameAsync(Empty request)
        {
            var path = "DataService/GetUserDataNameAsync";
            return InvokeAsync<UserDataGetNameResponse, Empty>(path, request,
                ctx =>
                    new ResponseContext<UserDataGetNameResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataNameAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<UserDataGetResponse> GetUserDataAsync(UserDataGetRequest request)
        {
            var path = "DataService/GetUserDataAsync";
            return InvokeAsync<UserDataGetResponse, UserDataGetRequest>(path, request,
                ctx =>
                    new ResponseContext<UserDataGetResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataAsync((UserDataGetRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IGachaService

        public Task<GetGachaListResponse> GetGachaListAsync(GetGachaListRequest request)
        {
            var path = "GachaService/GetGachaListAsync";
            return InvokeAsync<GetGachaListResponse, GetGachaListRequest>(path, request,
                ctx =>
                    new ResponseContext<GetGachaListResponse>(new GachaService.GachaServiceClient(GetCallInvoker(ctx.Channel)).GetGachaListAsync((GetGachaListRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<GetGachaResponse> GetGachaAsync(GetGachaRequest request)
        {
            var path = "GachaService/GetGachaAsync";
            return InvokeAsync<GetGachaResponse, GetGachaRequest>(path, request,
                ctx =>
                    new ResponseContext<GetGachaResponse>(new GachaService.GachaServiceClient(GetCallInvoker(ctx.Channel)).GetGachaAsync((GetGachaRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IExploreService

        public Task<StartExploreResponse> StartExploreAsync(StartExploreRequest request)
        {
            var path = "ExploreService/StartExploreAsync";
            return InvokeAsync<StartExploreResponse, StartExploreRequest>(path, request,
                ctx =>
                    new ResponseContext<StartExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).StartExploreAsync((StartExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<FinishExploreResponse> FinishExploreAsync(FinishExploreRequest request)
        {
            var path = "ExploreService/FinishExploreAsync";
            return InvokeAsync<FinishExploreResponse, FinishExploreRequest>(path, request,
                ctx =>
                    new ResponseContext<FinishExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).FinishExploreAsync((FinishExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<RetireExploreResponse> RetireExploreAsync(RetireExploreRequest request)
        {
            var path = "ExploreService/RetireExploreAsync";
            return InvokeAsync<RetireExploreResponse, RetireExploreRequest>(path, request,
                ctx =>
                    new ResponseContext<RetireExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).RetireExploreAsync((RetireExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IQuestService

        public Task<StartEventQuestResponse> StartEventQuestAsync(StartEventQuestRequest request)
        {
            var path = "QuestService/StartEventQuestAsync";
            return InvokeAsync<StartEventQuestResponse, StartEventQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<StartEventQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).StartEventQuestAsync((StartEventQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<FinishEventQuestResponse> FinishEventQuestAsync(FinishEventQuestRequest request)
        {
            var path = "QuestService/FinishEventQuestAsync";
            return InvokeAsync<FinishEventQuestResponse, FinishEventQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<FinishEventQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).FinishEventQuestAsync((FinishEventQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<StartMainQuestResponse> StartMainQuestAsync(StartMainQuestRequest request)
        {
            var path = "QuestService/StartMainQuestAsync";
            return InvokeAsync<StartMainQuestResponse, StartMainQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<StartMainQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).StartMainQuestAsync((StartMainQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<FinishMainQuestResponse> FinishMainQuestAsync(FinishMainQuestRequest request)
        {
            var path = "QuestService/FinishMainQuestAsync";
            return InvokeAsync<FinishMainQuestResponse, FinishMainQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<FinishMainQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).FinishMainQuestAsync((FinishMainQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<UpdateEventQuestSceneProgressResponse> UpdateEventQuestSceneProgressAsync(UpdateEventQuestSceneProgressRequest request)
        {
            var path = "QuestService/UpdateEventQuestSceneProgressAsync";
            return InvokeAsync<UpdateEventQuestSceneProgressResponse, UpdateEventQuestSceneProgressRequest>(path, request,
                ctx =>
                    new ResponseContext<UpdateEventQuestSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateEventQuestSceneProgressAsync((UpdateEventQuestSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<UpdateMainQuestSceneProgressResponse> UpdateMainQuestSceneProgressAsync(UpdateMainQuestSceneProgressRequest request)
        {
            var path = "QuestService/UpdateMainQuestSceneProgressAsync";
            return InvokeAsync<UpdateMainQuestSceneProgressResponse, UpdateMainQuestSceneProgressRequest>(path, request,
                ctx =>
                    new ResponseContext<UpdateMainQuestSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateMainQuestSceneProgressAsync((UpdateMainQuestSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<UpdateMainFlowSceneProgressResponse> UpdateMainFlowSceneProgressAsync(UpdateMainFlowSceneProgressRequest request)
        {
            var path = "QuestService/UpdateMainFlowSceneProgressAsync";
            return InvokeAsync<UpdateMainFlowSceneProgressResponse, UpdateMainFlowSceneProgressRequest>(path, request,
                ctx =>
                    new ResponseContext<UpdateMainFlowSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateMainFlowSceneProgressAsync((UpdateMainFlowSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IUserService

        public Task<AuthUserResponse> AuthAsync(AuthUserRequest request)
        {
            var path = "UserService/AuthAsync";
            return InvokeAsync<AuthUserResponse, AuthUserRequest>(path, request,
                ctx =>
                    new ResponseContext<AuthUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).AuthAsync((AuthUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<GetAndroidArgsResponse> GetAndroidArgsAsync(GetAndroidArgsRequest request)
        {
            var path = "UserService/GetAndroidArgsAsync";
            return InvokeAsync<GetAndroidArgsResponse, GetAndroidArgsRequest>(path, request,
                ctx =>
                    new ResponseContext<GetAndroidArgsResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetAndroidArgsAsync((GetAndroidArgsRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<GetBackupTokenResponse> GetBackupTokenAsync(GetBackupTokenRequest request)
        {
            var path = "UserService/GetBackupTokenAsync";
            return InvokeAsync<GetBackupTokenResponse, GetBackupTokenRequest>(path, request,
                ctx =>
                    new ResponseContext<GetBackupTokenResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetBackupTokenAsync((GetBackupTokenRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<TransferUserResponse> TransferUserAsync(TransferUserRequest request)
        {
            var path = "UserService/TransferUserAsync";
            return InvokeAsync<TransferUserResponse, TransferUserRequest>(path, request,
                ctx =>
                    new ResponseContext<TransferUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserAsync((TransferUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<GetChargeMoneyResponse> GetChargeMoneyAsync(Empty request)
        {
            var path = "UserService/GetChargeMoneyAsync";
            return InvokeAsync<GetChargeMoneyResponse, Empty>(path, request,
                ctx =>
                    new ResponseContext<GetChargeMoneyResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetChargeMoneyAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IBigHuntService

        public Task<StartBigHuntQuestResponse> StartBigHuntQuestAsync(StartBigHuntQuestRequest request)
        {
            var path = "BigHuntService/StartBigHuntQuestAsync";
            return InvokeAsync<StartBigHuntQuestResponse, StartBigHuntQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<StartBigHuntQuestResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).StartBigHuntQuestAsync((StartBigHuntQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<FinishBigHuntQuestResponse> FinishBigHuntQuestAsync(FinishBigHuntQuestRequest request)
        {
            var path = "BigHuntService/FinishBigHuntQuestAsync";
            return InvokeAsync<FinishBigHuntQuestResponse, FinishBigHuntQuestRequest>(path, request,
                ctx =>
                    new ResponseContext<FinishBigHuntQuestResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).FinishBigHuntQuestAsync((FinishBigHuntQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<SaveBigHuntBattleInfoResponse> SaveBigHuntBattleInfoAsync(SaveBigHuntBattleInfoRequest request)
        {
            var path = "BigHuntService/StartBigHuntQuestAsync";
            return InvokeAsync<SaveBigHuntBattleInfoResponse, SaveBigHuntBattleInfoRequest>(path, request,
                ctx =>
                    new ResponseContext<SaveBigHuntBattleInfoResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).SaveBigHuntBattleInfoAsync((SaveBigHuntBattleInfoRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region IDeckService 

        public Task<UpdateNameResponse> UpdateNameAsync(UpdateNameRequest request)
        {
            var path = "DeckService/UpdateNameAsync";
            return InvokeAsync<UpdateNameResponse, UpdateNameRequest>(path, request,
                ctx =>
                    new ResponseContext<UpdateNameResponse>(new DeckService.DeckServiceClient(GetCallInvoker(ctx.Channel)).UpdateNameAsync((UpdateNameRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        public Task<ReplaceDeckResponse> ReplaceDeckAsync(ReplaceDeckRequest request)
        {
            var path = "DeckService/ReplaceDeckAsync";
            return InvokeAsync<ReplaceDeckResponse, ReplaceDeckRequest>(path, request,
                ctx =>
                    new ResponseContext<ReplaceDeckResponse>(new DeckService.DeckServiceClient(GetCallInvoker(ctx.Channel)).ReplaceDeckAsync((ReplaceDeckRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
        }

        #endregion

        #region Invokation methods

        // Done
        private async Task<TResponse> InvokeAsync<TResponse, TRequest>(string path, TRequest request, Func<RequestContext, ResponseContext> requestMethod)
        {
            var reqContext = new RequestContext(this, path, request, channel, new Metadata(), deadline, cancellationToken, interceptors, requestMethod, typeof(TResponse), OnErrorAction, OnVerifyToken);
            var resContext = await InvokeWithInterceptor(reqContext);

            if (resContext == null)
                return default;

            return await resContext.GetResponseAs<TResponse>();
        }

        // Done
        private static Task<ResponseContext> InvokeWithInterceptor(RequestContext context)
        {
            return InvokeRecursive(context);
        }

        // Done
        private static Task<ResponseContext> InvokeRecursive(RequestContext context, int index = -1)
        {
            if (context.Interceptors.Length - 1 == index)
                return context.RequestMethod?.Invoke(context).WaitResponseAsync();

            if (context.Interceptors.Length <= index + 1)
                throw new IndexOutOfRangeException();

            var interceptor = context.Interceptors[index + 1];
            return interceptor.SendAsync(context, reqCtx => InvokeRecursive(context, index + 1));
        }

        #endregion

        public static string CreateVerifierToken()
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes($"{ApplicationScopeClientContext.Instance.User.UserId}{ApplicationScopeClientContext.Instance.Token.Value}"));
            return Convert.ToHexString(hash).ToLower();
        }

        // CUSTOM: A custom method to inject de-/encryption of gRPC messages through PayloadCallInvoker
        // PayloadCallInvoker delegates are set in Dark.StateMachine.HandleNet.Initialize
        private CallInvoker GetCallInvoker(Channel c)
        {
            return new PayloadCallInvoker(c);
        }
    }
}
