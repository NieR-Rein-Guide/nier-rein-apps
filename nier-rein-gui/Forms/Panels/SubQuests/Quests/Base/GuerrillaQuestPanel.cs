using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests.Base
{
    partial class GuerrillaQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        public GuerrillaQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            UpdateContent();
        }

        private void UpdateContent()
        {
            UpdateTimeTable(GetTimeTableText());

            var timeTable = GetTimeTable();
            var isInTerm = timeTable.Any(t => CalculatorDateTime.IsWithinThePeriod(t.Start, t.End));

            if (isInTerm)
            {
                var panel = new GuerillaQuestListPanel(_rein);
                panel.FightFinish += Panel_FightFinish;

                Content = panel;
            }
            else
                Content = timePanel;
        }

        private string GetTimeTableText()
        {
            return CalculatorGuerrillaQuest.GetGuerrillaQuestTimeTableText(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        }

        private List<Term> GetTimeTable()
        {
            return CalculatorQuest.GetCurrentEventChapterTodayTimeTable(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        }

        private void Panel_FightFinish(object sender, System.EventArgs e)
        {
            UpdateContent();
        }
    }
}
