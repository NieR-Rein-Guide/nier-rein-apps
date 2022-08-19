using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class GuerrillaQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        public GuerrillaQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            UpdateTimeTable(GetTimeTableText());
            //UpdateFreeUnlocks();

            UpdateContent();
        }

        private void UpdateContent()
        {
            var timeTable = GetTimeTable();
            if (timeTable.Any(t => CalculatorDateTime.IsWithinThePeriod(t.Start, t.End)))
            {
                var quests = CalculatorQuest.GetTodayGuerrillaQuestData();
                UpdateQuestList(quests, timeTable);

                Content = questPanel;

                return;
            }

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
    }
}
