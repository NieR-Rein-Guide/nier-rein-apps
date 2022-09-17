using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Modals;
using nier_rein_gui.Dialogs;
using nier_rein_gui.Dialogs.FarmDialogs;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests
{
    class EventQuestListPanel : QuestListPanel<EventQuestData>
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
            Modal farmDlg;
            switch (_chapter.EventQuestType)
            {
                case EventQuestType.TOWER:
                    farmDlg = new TowerDialog(_rein, quests, quest);
                    break;

                case EventQuestType.DUNGEON:
                    farmDlg = new MemoirFarmDialog(_rein, quest);
                    break;

                default:
                    farmDlg = new EventQuestFarmDialog(_rein, quests, quest);
                    break;
            }

            await farmDlg.ShowAsync();
        }
    }
}
