using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class LimitQuestFarmDialog : QuestFarmDialog<EventQuestData>
    {
        public LimitQuestFarmDialog(NierReinContexts rein, IList<EventQuestData> questList, EventQuestData quest) :
            base(rein, questList, quest, DeckType.RESTRICTED_LIMIT_CONTENT_QUEST)
        {
        }

        protected override int GetQuestId(EventQuestData data)
        {
            return data.Quest.QuestId;
        }

        protected override string GetQuestName(EventQuestData data)
        {
            return data.QuestName;
        }

        protected override int GetQuestDailyCount(EventQuestData data)
        {
            return data.Quest.EntityQuest.DailyClearableCount;
        }

        protected override bool IsQuestLocked(EventQuestData data)
        {
            return CalculatorQuest.IsQuestLocked(data.Quest.QuestId);
        }

        protected override void SetQuestLocked(EventQuestData data, bool isLock)
        {
            data.IsLock = isLock;
        }

        protected override IEnumerable<DataDeckInfo> EnumerateDecks(IList<EventQuestData> quests, EventQuestData quest, DeckType deckType)
        {
            var limitCharacter = CalculatorLimitContent.CreateDataLimitContentCharacter(quest.Quest.QuestId);

            var index = quests.IndexOf(quest);
            var baseIndex = limitCharacter.SortOrder * 100;
            return base.EnumerateDecks(quests, quest, deckType).Where(x => x.UserDeckNumber == baseIndex + index + 1);
        }

        protected override Task<BattleResult> ExecuteQuest(EventQuestData quest, DataDeck deck)
        {
            return BattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);
        }
    }
}
