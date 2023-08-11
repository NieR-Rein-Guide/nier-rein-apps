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

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Grpc.Api;

public static class UserDiffInfo
{
    public static MapField<string, DiffData> GetUserDiff(ResponseContext responseContext)
    {
        return responseContext.ResponseType.FullName switch
        {
            "Art.Framework.ApiNetwork.Grpc.Api.User.GetAndroidArgsResponse" => responseContext.GetResponseAs<GetAndroidArgsResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Deck.UpdateNameResponse" => responseContext.GetResponseAs<UpdateNameResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Deck.ReplaceDeckResponse" => responseContext.GetResponseAs<ReplaceDeckResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Deck.RemoveDeckResponse" => responseContext.GetResponseAs<RemoveDeckResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.StartBigHuntQuestResponse" => responseContext.GetResponseAs<StartBigHuntQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.FinishBigHuntQuestResponse" => responseContext.GetResponseAs<FinishBigHuntQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.BigHunt.SaveBigHuntBattleInfoResponse" => responseContext.GetResponseAs<SaveBigHuntBattleInfoResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateMainFlowSceneProgressResponse" => responseContext.GetResponseAs<UpdateMainFlowSceneProgressResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.StartMainQuestResponse" => responseContext.GetResponseAs<StartMainQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.FinishMainQuestResponse" => responseContext.GetResponseAs<FinishMainQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateMainQuestSceneProgressResponse" => responseContext.GetResponseAs<UpdateMainQuestSceneProgressResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.StartEventQuestResponse" => responseContext.GetResponseAs<StartEventQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.FinishEventQuestResponse" => responseContext.GetResponseAs<FinishEventQuestResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.UpdateEventQuestSceneProgressResponse" => responseContext.GetResponseAs<UpdateEventQuestSceneProgressResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Quest.ReceiveDailyQuestGroupCompleteRewardResponse" => responseContext.GetResponseAs<ReceiveDailyQuestGroupCompleteRewardResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Battle.StartWaveResponse" => responseContext.GetResponseAs<StartWaveResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Battle.FinishWaveResponse" => responseContext.GetResponseAs<FinishWaveResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem.UseEffectItemResponse" => responseContext.GetResponseAs<UseEffectItemResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.Gimmick.UpdateGimmickProgressResponse" => responseContext.GetResponseAs<UpdateGimmickProgressResponse>().Result?.DiffUserData,
            "Art.Framework.ApiNetwork.Grpc.Api.CageOrnament.ReceiveRewardResponse" => responseContext.GetResponseAs<ReceiveRewardResponse>().Result?.DiffUserData,
            _ => null,
        };
    }
}
