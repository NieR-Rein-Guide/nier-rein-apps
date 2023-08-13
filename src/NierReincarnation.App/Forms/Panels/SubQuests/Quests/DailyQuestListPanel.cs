using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests
{
    internal class DailyQuestListPanel : QuestListPanel<EventQuestData>
    {
        private readonly NierReinContexts _rein;

        public DailyQuestListPanel(NierReinContexts reinContexts) : base(string.Empty, new[] { DifficultyType.NORMAL })
        {
            _rein = reinContexts;

            UpdateQuestList(CurrentDifficulty);
        }

        protected override IQuest GetBaseQuest(EventQuestData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(EventQuestData quest)
        {
            return quest.QuestName;
        }

        protected override IList<EventQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            return CalculatorQuest.GetTodayDailyQuestData();
        }

        protected override async Task FightAsync(IList<EventQuestData> quests, EventQuestData quest)
        {
            var farmDlg = new TimedQuestFarmDialog(_rein, quests, quest, new List<Term> { Term.CurrentDay });
            await farmDlg.ShowAsync();
        }
    }
}
