using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGuiNET;
using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters.LimitQuest
{
    internal class LimitQuestListPanel : ClosableQuestListPanel<EventQuestData>
    {
        private readonly NierReinContexts _rein;
        private readonly IList<EventQuestData> _quests;

        public LimitQuestListPanel(NierReinContexts rein, string name, IList<EventQuestData> quests, DifficultyType difficulty) : base(name, new[] { difficulty })
        {
            _rein = rein;
            _quests = quests;

            UpdateQuestList(difficulty);
        }

        protected override void InitializeComponent(StackLayout listLayout)
        {
            var backBtn = new ArrowButton { Direction = ImGuiDir.Left };
            backBtn.Clicked += BackBtn_Clicked;

            (listLayout.Items[0].Content as StackLayout)?.Items.Insert(0, backBtn);
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            OnClose();
        }

        protected override IList<EventQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            return _quests;
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
            var farmDlg = new LimitQuestFarmDialog(_rein, quests, quest);
            await farmDlg.ShowAsync();
        }
    }
}
