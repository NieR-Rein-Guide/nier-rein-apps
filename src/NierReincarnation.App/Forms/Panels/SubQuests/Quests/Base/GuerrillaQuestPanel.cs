using ImGui.Forms.Controls;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base
{
    internal partial class GuerrillaQuestPanel : Panel
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
            {
                Content = timePanel;
            }
        }

        private static string GetTimeTableText()
        {
            return CalculatorGuerrillaQuest.GetGuerrillaQuestTimeTableText(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        }

        private static List<Term> GetTimeTable()
        {
            return CalculatorQuest.GetCurrentEventChapterTodayTimeTable(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        }

        private void Panel_FightFinish(object sender, System.EventArgs e)
        {
            UpdateContent();
        }
    }
}
