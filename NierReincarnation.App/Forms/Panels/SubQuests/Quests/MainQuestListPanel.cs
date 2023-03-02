using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests
{
    internal class MainQuestListPanel : QuestListPanel<QuestCellData>
    {
        private readonly NierReinContexts _rein;
        private readonly MainQuestChapterData _chapter;

        public MainQuestListPanel(NierReinContexts rein, MainQuestChapterData chapter) :
            base(chapter.MainQuestChapterName, chapter.MainQuestChapterDifficultyTypes)
        {
            _rein = rein;
            _chapter = chapter;

            UpdateQuestList(chapter.MainQuestChapterDifficultyTypes[0]);
        }

        protected override IList<QuestCellData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            return CalculatorQuest.GenerateMainQuestData(_chapter.MainQuestChapterId, difficulty).QuestDataList;
        }

        protected override IQuest GetBaseQuest(QuestCellData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(QuestCellData quest)
        {
            return quest.QuestName;
        }

        protected override async Task FightAsync(IList<QuestCellData> quests, QuestCellData quest)
        {
            var farmDlg = new MainQuestFarmDialog(_rein, quests, quest);
            await farmDlg.ShowAsync();
        }
    }
}
