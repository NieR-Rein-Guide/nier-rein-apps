using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGuiNET;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests
{
    class DungeonQuestListPanel : ClosableQuestListPanel<EventQuestData>
    {
        private readonly EventQuestChapterData _chapter;

        public DungeonQuestListPanel(EventQuestChapterData chapter) : base(chapter.EventQuestName, chapter.EventQuestChapterDifficultyTypes)
        {
            _chapter = chapter;

            UpdateQuestList(chapter.EventQuestChapterDifficultyTypes[0]);
        }

        protected override void InitializeComponent(StackLayout listLayout)
        {
            var backBtn = new ArrowButton { Direction = ImGuiDir.Left };
            backBtn.Clicked += BackBtn_Clicked;

            (listLayout.Items[0].Content as StackLayout).Items.Insert(0, backBtn);
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            OnClose();
        }

        protected override IList<EventQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            return CalculatorQuest.GenerateEventQuestData(_chapter.EventQuestChapterId, difficulty);
        }

        protected override IQuest GetBaseQuest(EventQuestData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(EventQuestData quest)
        {
            return quest.QuestName;
        }

        protected override async Task FightAsync(IList<EventQuestData> quests, EventQuestData quest)
        {
            await MessageBox.ShowErrorAsync(LocalizationResources.DungeonUnavailableTitle, LocalizationResources.DungeonUnavailableDescription);
        }
    }
}
