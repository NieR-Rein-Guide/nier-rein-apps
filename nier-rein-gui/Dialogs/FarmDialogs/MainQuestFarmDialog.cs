using System.Collections.Generic;
using System.Threading.Tasks;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    class MainQuestFarmDialog : QuestFarmDialog
    {
        private readonly IList<QuestCellData> _questList;

        private QuestCellData _quest;

        public MainQuestFarmDialog(NierReinContexts rein, IList<QuestCellData> quests, QuestCellData quest) : 
            base(rein, quest.Quest.QuestId, quest.QuestName)
        {
            _questList = quests;
            _quest = quest;
        }

        protected override int NextQuest(out string questName)
        {
            var start = _questList.IndexOf(_quest);
            for (var i = start + 1; i < start + _questList.Count; i++)
            {
                var quest = _questList[i % _questList.Count];
                if (!CalculatorQuest.IsUnlockedQuest(quest.Quest.QuestId))
                    continue;

                _quest = quest;
                quest.IsLock = false;

                questName = quest.QuestName;
                return quest.Quest.QuestId;
            }

            questName = _quest.QuestName;
            return _quest.Quest.QuestId;
        }

        protected override int PreviousQuest(out string questName)
        {
            var start = _questList.IndexOf(_quest);
            for (var i = start - 1; i >= start - _questList.Count; i--)
            {
                var quest = _questList[i < 0 ? _questList.Count + i : i];
                if (!CalculatorQuest.IsUnlockedQuest(quest.Quest.QuestId))
                    continue;

                _quest = quest;
                quest.IsLock = false;

                questName = quest.QuestName;
                return quest.Quest.QuestId;
            }

            questName = _quest.QuestName;
            return _quest.Quest.QuestId;
        }

        protected override Task<BattleResult> ExecuteQuest(DataDeck deck)
        {
            return BattleContext.ExecuteMainQuest(_quest, deck);
        }
    }
}
