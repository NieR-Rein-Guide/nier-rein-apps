using System;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;
using Art.Framework.ApiNetwork.Grpc.Api.Gimmick;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Context
{
    public class GimmickContext : BaseContext
    {
        private readonly DarkClient _dc = new DarkClient();

        internal GimmickContext()
        { }

        public bool IsGimmickQuest(WorldMapGimmickOutGame gimmick)
        {
            return gimmick.GimmickType == GimmickType.MAP_ONLY_HIDE_OBELISK;
        }

        public async Task Execute(WorldMapGimmickOutGame gimmick, DataDeck deck)
        {
            switch (gimmick.GimmickType)
            {
                // Stray Scarecrows
                case GimmickType.MAP_ONLY_HIDE_OBELISK:
                    await CollectHideObelisk(gimmick, deck);
                    break;
            }
        }

        public async Task Collect(WorldMapGimmickOutGame gimmick)
        {
            switch (gimmick.GimmickType)
            {
                // Lost Items
                case GimmickType.CAGE_INTERVAL_DROP_ITEM:
                case GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM:

                // Fickle Black Birds
                case GimmickType.CAGE_TREASURE_HUNT:
                    await CollectGimmickRewards(gimmick);
                    break;

                // Black Birds
                case GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT:
                    await CollectCageOrnament(gimmick);
                    break;

                // Stray Scarecrows
                case GimmickType.MAP_ONLY_HIDE_OBELISK:
                    throw new InvalidOperationException($"Quest gimmicks should be collected by using '{nameof(Execute)}'.");

                default:
                    throw new InvalidOperationException("Gimmick cannot be collected.");
            }
        }

        private Task CollectGimmickRewards(WorldMapGimmickOutGame gimmick)
        {
            return TryRequest(() =>
            {
                var req = new UpdateGimmickProgressRequest
                {
                    GimmickSequenceScheduleId = gimmick.GimmickSequenceScheduleId,
                    GimmickSequenceId = gimmick.GimmickSequenceId,
                    GimmickId = gimmick.GimmickId,
                    GimmickOrnamentIndex = gimmick.GimmickOrnamentIndex,
                    ProgressValueBit = gimmick.UserGimmickProgressValueBit | (1 << (gimmick.GimmickOrnamentIndex - 1)),
                    FlowType = gimmick.GimmickFlowType
                };
                return _dc.GimmickService.UpdateGimmickProgressAsync(req);
            });
        }

        private Task CollectCageOrnament(WorldMapGimmickOutGame gimmick)
        {
            return TryRequest(() =>
            {
                var req = new ReceiveRewardRequest
                {
                    CageOrnamentId = gimmick.CageOrnamentId
                };
                return _dc.CageOrnamentService.ReceiveRewardAsync(req);
            });
        }

        private Task CollectHideObelisk(WorldMapGimmickOutGame gimmick, DataDeck deck)
        {
            if (deck.DeckType != DeckType.RESTRICTED_QUEST)
                throw new InvalidOperationException("Gimmick quests can only be executed with a restricted deck.");

            var questContext = NierReincarnation.GetContexts().Battles.CreateQuestContext();
            var gimmickQuest = CalculatorWorldMap.GetHideObeliskQuest(gimmick.GimmickId, gimmick.GimmickOrnamentIndex);

            return questContext.ExecuteExtraQuest(gimmickQuest, deck);
        }
    }
}
