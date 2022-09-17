using Art.Framework.ApiNetwork.Grpc.Api.Battle;
using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;
using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;
using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;
using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using Art.Framework.ApiNetwork.Grpc.Api.Gimmick;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.Collections;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api
{
    // Art.Framework.ApiNetwork.Grpc.Api.UserDiffInfo
    static class UserDiffInfo
    {
        public static MapField<string, DiffData> GetUserDiff(ResponseContext responseContext)
        {
            // Do switch-case type check and get userDiffInfo from GRPC message based on response type

            switch (responseContext.ResponseType.FullName)
            {
                case "Art.Framework.ApiNetwork.Grpc.Api.User.GetAndroidArgsResponse":
                    return responseContext.GetResponseAs<GetAndroidArgsResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.Deck.UpdateNameResponse":
                    return responseContext.GetResponseAs<UpdateNameResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Deck.ReplaceDeckResponse":
                    return responseContext.GetResponseAs<ReplaceDeckResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Deck.RemoveDeckResponse":
                    return responseContext.GetResponseAs<RemoveDeckResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.StartBigHuntQuestResponse":
                    return responseContext.GetResponseAs<StartBigHuntQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.FinishBigHuntQuestResponse":
                    return responseContext.GetResponseAs<FinishBigHuntQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.SaveBigHuntBattleInfoResponse":
                    return responseContext.GetResponseAs<SaveBigHuntBattleInfoResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateMainFlowSceneProgressResponse":
                    return responseContext.GetResponseAs<UpdateMainFlowSceneProgressResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.StartMainQuestResponse":
                    return responseContext.GetResponseAs<StartMainQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.FinishMainQuestResponse":
                    return responseContext.GetResponseAs<FinishMainQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateMainQuestSceneProgressResponse":
                    return responseContext.GetResponseAs<UpdateMainQuestSceneProgressResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.StartEventQuestResponse":
                    return responseContext.GetResponseAs<StartEventQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.FinishEventQuestResponse":
                    return responseContext.GetResponseAs<FinishEventQuestResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateEventQuestSceneProgressResponse":
                    return responseContext.GetResponseAs<UpdateEventQuestSceneProgressResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.Battle.StartWaveResponse":
                    return responseContext.GetResponseAs<StartWaveResponse>().Result?.DiffUserData;
                case "Art.Framework.ApiNetwork.Grpc.Api.Battle.FinishWaveResponse":
                    return responseContext.GetResponseAs<FinishWaveResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem.UseEffectItemResponse":
                    return responseContext.GetResponseAs<UseEffectItemResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.Gimmick.UpdateGimmickProgressResponse":
                    return responseContext.GetResponseAs<UpdateGimmickProgressResponse>().Result?.DiffUserData;

                case "Art.Framework.ApiNetwork.Grpc.Api.CageOrnament.ReceiveRewardResponse":
                    return responseContext.GetResponseAs<ReceiveRewardResponse>().Result?.DiffUserData;

                default:
                    return null;
            }
        }
    }
}
