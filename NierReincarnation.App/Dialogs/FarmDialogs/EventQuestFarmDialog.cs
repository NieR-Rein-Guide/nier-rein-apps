using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class EventQuestFarmDialog : QuestFarmDialog<EventQuestData>
    {
        public EventQuestFarmDialog(NierReinContexts rein, IList<EventQuestData> questList, EventQuestData quest, DeckType deckType = DeckType.QUEST) :
            base(rein, questList, quest, deckType)
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

        protected override Task<BattleResult> ExecuteQuest(EventQuestData quest, DataDeck deck)
        {
            return BattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);
        }
    }
}
