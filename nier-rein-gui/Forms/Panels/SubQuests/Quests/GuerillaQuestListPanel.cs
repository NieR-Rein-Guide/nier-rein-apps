using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using nier_rein_gui.Dialogs.FarmDialogs;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests
{
    class GuerillaQuestListPanel : QuestListPanel<EventQuestData>
    {
        private readonly NierReinContexts _rein;

        public event EventHandler FightFinish;

        public GuerillaQuestListPanel(NierReinContexts rein) : base(string.Empty, new[] { DifficultyType.NORMAL })
        {
            _rein = rein;

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
            return CalculatorQuest.GetTodayGuerrillaQuestData();
        }

        protected override async Task FightAsync(IList<EventQuestData> quests, EventQuestData quest)
        {
            var timeTable = CalculatorQuest.GetCurrentEventChapterTodayTimeTable(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());

            var farmDlg = new TimedQuestFarmDialog(_rein, quests, quest, timeTable);
            await farmDlg.ShowAsync();

            OnFightFinish();
        }

        private void OnFightFinish()
        {
            FightFinish?.Invoke(this, new EventArgs());
        }
    }
}
