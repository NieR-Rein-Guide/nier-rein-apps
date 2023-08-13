using ImGui.Forms.Modals;
using NierReincarnation.App.Dialogs;
using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests
{
    internal class EventQuestListPanel : QuestListPanel<EventQuestData>
    {
        private readonly NierReinContexts _rein;
        private readonly EventQuestChapterData _chapter;

        public int ChapterId => _chapter.EventQuestChapterId;

        public EventQuestListPanel(NierReinContexts reinContexts, EventQuestChapterData chapter) :
            base(chapter.EventQuestName, chapter.EventQuestChapterDifficultyTypes)
        {
            _rein = reinContexts;
            _chapter = chapter;

            UpdateQuestList(CurrentDifficulty);
        }

        protected override IQuest GetBaseQuest(EventQuestData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(EventQuestData quest)
        {
            return quest.QuestName;
        }

        protected override IList<EventQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            var eventQuests = CalculatorQuest.GenerateEventQuestData(_chapter.EventQuestChapterId, difficulty);
            return eventQuests.Where(x => x.IsAvailable).ToArray();
        }

        protected override async Task FightAsync(IList<EventQuestData> quests, EventQuestData quest)
        {
            Modal farmDlg = _chapter.EventQuestType switch
            {
                EventQuestType.TOWER or EventQuestType.LABYRINTH => new TowerDialog(_rein, quests, quest, _chapter.EventQuestType),
                EventQuestType.DUNGEON => new MemoirFarmDialog(_rein, quest),
                _ => new EventQuestFarmDialog(_rein, quests, quest),
            };
            await farmDlg.ShowAsync();
        }
    }
}
