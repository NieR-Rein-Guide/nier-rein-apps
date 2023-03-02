using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class MainQuestFarmDialog : QuestFarmDialog<QuestCellData>
    {
        public MainQuestFarmDialog(NierReinContexts rein, IList<QuestCellData> quests, QuestCellData quest) :
            base(rein, quests, quest, DeckType.QUEST)
        {
        }

        protected override int GetQuestId(QuestCellData data)
        {
            return data.Quest.QuestId;
        }

        protected override string GetQuestName(QuestCellData data)
        {
            return data.QuestName;
        }

        protected override int GetQuestDailyCount(QuestCellData data)
        {
            return data.Quest.EntityQuest.DailyClearableCount;
        }

        protected override bool IsQuestLocked(QuestCellData data)
        {
            return CalculatorQuest.IsQuestLocked(data.Quest.QuestId);
        }

        protected override void SetQuestLocked(QuestCellData data, bool isLock)
        {
            data.IsLock = isLock;
        }

        protected override Task<BattleResult> ExecuteQuest(QuestCellData quest, DataDeck deck)
        {
            return BattleContext.ExecuteMainQuest(quest, deck);
        }
    }
}
