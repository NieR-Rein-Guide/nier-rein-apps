using System.Collections.Generic;
using System.Threading.Tasks;
using ImGui.Forms.Modals;
using nier_rein_gui.Dialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    class EventQuestPanel : QuestPanel
    {
        public EventQuestPanel(NierReinContexts reinContexts, EventQuestChapterData chapter) : base(reinContexts, chapter)
        { }

        protected override async Task FightAsync(EventQuestChapterData chapter, DifficultyType type, IList<EventQuestData> quests, EventQuestData quest)
        {
            Modal farmDlg;
            if (chapter.EventQuestType == EventQuestType.TOWER)
                farmDlg = new TowerDialog(ReinContexts, chapter.EventQuestChapterId, quests, quest);
            else
                farmDlg = new EventQuestFarmDialog(ReinContexts, chapter.EventQuestChapterId, quests, quest);

            await farmDlg.ShowAsync();

            SetQuestList(chapter, type);
        }
    }
}
