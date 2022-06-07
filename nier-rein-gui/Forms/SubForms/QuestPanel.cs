using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    abstract partial class QuestPanel : Panel
    {
        private readonly EventQuestChapterData _chapter;
        private DifficultyType _diffType;

        protected NierReinContexts ReinContexts { get; }

        public int ChapterId => _chapter.EventQuestChapterId;

        public QuestPanel(NierReinContexts reinContexts, EventQuestChapterData chapter)
        {
            ReinContexts = reinContexts;

            _chapter = chapter;
            _diffType = chapter.EventQuestChapterDifficultyTypes[0];

            InitializeComponent(chapter);
            SetQuestList(chapter, _diffType);

            if (difficultyButton != null)
                difficultyButton.Clicked += DifficultyButton_Clicked;
        }

        private void DifficultyButton_Clicked(object sender, EventArgs e)
        {
            var diffIndex = _chapter.EventQuestChapterDifficultyTypes.IndexOf(_diffType);

            diffIndex++;
            if (diffIndex >= _chapter.EventQuestChapterDifficultyTypes.Count)
                diffIndex = 0;

            _diffType = _chapter.EventQuestChapterDifficultyTypes[diffIndex];
            difficultyButton.Caption = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)_diffType).Localize();

            SetQuestList(_chapter, _diffType);
        }

        private IList<EventQuestData> GetChapterQuests(EventQuestChapterData chapter, DifficultyType type)
        {
            return ReinContexts.Quests.GetEventQuests(chapter.EventQuestChapterId, type).Where(x => x.IsAvailable).ToArray();
        }

        protected abstract Task FightAsync(EventQuestChapterData chapter, DifficultyType type, IList<EventQuestData> quests, EventQuestData quest);
    }
}
