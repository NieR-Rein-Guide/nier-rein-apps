using System.Collections.Generic;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class DailyQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        public DailyQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            UpdateQuestList();
        }

        private List<EventQuestData> GetTodayQuests()
        {
            return CalculatorQuest.GetTodayDailyQuestData();
        }
    }
}
