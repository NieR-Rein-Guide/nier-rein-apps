using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests.Base
{
    abstract partial class QuestListPanel<TQuestData> : Panel
    {
        private readonly IList<DifficultyType> _difficulties;

        protected DifficultyType CurrentDifficulty { get; private set; }

        public QuestListPanel(string name, IList<DifficultyType> difficulties)
        {
            _difficulties = difficulties;
            CurrentDifficulty = difficulties[0];

            InitializeComponent(name, difficulties);

            if (difficultyButton != null)
                difficultyButton.Clicked += DifficultyButton_Clicked;
        }

        private void DifficultyButton_Clicked(object sender, EventArgs e)
        {
            var diffIndex = _difficulties.IndexOf(CurrentDifficulty);

            diffIndex++;
            if (diffIndex >= _difficulties.Count)
                diffIndex = 0;

            CurrentDifficulty = _difficulties[diffIndex];
            difficultyButton.Text = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)CurrentDifficulty).Localize();

            UpdateQuestList(CurrentDifficulty);
        }

        protected abstract IList<TQuestData> GetQuestsByDifficulty(DifficultyType difficulty);

        protected abstract Task FightAsync(IList<TQuestData> quests, TQuestData quest);
    }
}
