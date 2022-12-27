using System;
using System.Collections.Generic;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGuiNET;
using nier_rein_gui.Forms.Panels.SubQuests.Characters.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests
{
    class DungeonQuestPanel : ButtonListPanel<EventQuestChapterData, ClosableQuestListPanel<EventQuestData>>
    {
        private readonly NierReinContexts _rein;

        public DungeonQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<EventQuestChapterData> GetDataElements()
        {
            return CalculatorQuest.GetEventQuestChapters(EventQuestType.DUNGEON);
        }

        protected override string GetCaption(EventQuestChapterData chapter)
        {
            return chapter.EventQuestName;
        }

        protected override bool IsButtonEnabled(EventQuestChapterData chapter)
        {
            return false; //chapter.IsCurrent();
        }

        protected override ClosableQuestListPanel<EventQuestData> CreatePanel(EventQuestChapterData chapter, IList<EventQuestChapterData> chapters)
        {
            return new DungeonQuestListPanel(chapter);
        }

        //private readonly NierReinContexts _rein;

        //public DungeonQuestPanel(NierReinContexts rein)
        //{
        //    _rein = rein;

        //    InitializeComponent();

        //    UpdateContent();
        //}

        //private void UpdateContent()
        //{
        //    UpdateTimeTable(GetTimeTableText());

        //    var timeTable = GetTimeTable();
        //    var isInTerm = timeTable.Any(t => CalculatorDateTime.IsWithinThePeriod(t.Start, t.End));

        //    if (isInTerm)
        //    {
        //        var panel = new GuerillaQuestListPanel(_rein);
        //        panel.FightFinish += Panel_FightFinish;

        //        Content = panel;
        //    }
        //    else
        //        Content = timePanel;
        //}

        //private string GetTimeTableText()
        //{
        //    return CalculatorGuerrillaQuest.GetGuerrillaQuestTimeTableText(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        //}

        //private List<Term> GetTimeTable()
        //{
        //    return CalculatorQuest.GetCurrentEventChapterTodayTimeTable(CalculatorGuerrillaQuest.GetGuerrillaEventChapterId());
        //}

        //private void Panel_FightFinish(object sender, System.EventArgs e)
        //{
        //    UpdateContent();
        //}
    }
}
