using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class LimitDailyFarmDialog : QuestFarmDialog<LimitDailyQuestData>
    {
        public LimitDailyFarmDialog(NierReinContexts rein, IList<LimitDailyQuestData> quests, LimitDailyQuestData currentQuest) : base(rein, quests, currentQuest, DeckType.QUEST)
        {
        }

        protected override int GetQuestId(LimitDailyQuestData data)
        {
            return data.Quest.QuestId;
        }

        protected override string GetQuestName(LimitDailyQuestData data)
        {
            return string.Empty;
        }

        protected override int GetQuestDailyCount(LimitDailyQuestData data)
        {
            return data.Quest.EntityQuest.DailyClearableCount;
        }

        protected override bool IsQuestLocked(LimitDailyQuestData data)
        {
            return CalculatorQuest.IsQuestLocked(data.Quest.QuestId);
        }

        protected override void SetQuestLocked(LimitDailyQuestData data, bool isLock)
        {
            data.IsLock = isLock;
        }

        protected override Task<BattleResult> ExecuteQuest(LimitDailyQuestData quest, DataDeck deck)
        {
            return BattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);
        }
    }
}
