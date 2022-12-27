using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Modals;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    class HideObeliskFarmDialog : QuestFarmDialog<EntityMQuest>
    {
        private readonly QuestBattleContext _battle;

        public HideObeliskFarmDialog(NierReinContexts rein, EntityMQuest questId) : base(rein, new[] { questId }, questId, DeckType.RESTRICTED_QUEST)
        {
            _battle = rein.Battles.CreateQuestContext();
        }

        protected override int GetQuestId(EntityMQuest data)
        {
            return data.QuestId;
        }

        protected override string GetQuestName(EntityMQuest data)
        {
            return string.Empty;
        }

        protected override int GetQuestDailyCount(EntityMQuest data)
        {
            return data.DailyClearableCount;
        }

        protected override bool IsQuestLocked(EntityMQuest data)
        {
            return CalculatorQuest.IsQuestLocked(data.QuestId);
        }

        protected override void SetQuestLocked(EntityMQuest data, bool isLock)
        {
        }

        protected override async Task<BattleResult> ExecuteQuest(EntityMQuest quest, DataDeck deck)
        {
            var result = await _battle.ExecuteExtraQuest(quest, deck);
            if (result.Status == BattleStatus.Win)
                Close(DialogResult.Ok);

            return result;
        }

        protected override IEnumerable<DataDeckInfo> EnumerateDecks(IList<EntityMQuest> quests, EntityMQuest quest, DeckType deckType)
        {
            return base.EnumerateDecks(quests, quest, deckType).Where(x => x.UserDeckNumber == 1);
        }
    }
}
