using System.Threading.Tasks;
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

        protected override async Task FightAsync(EventQuestChapterData chapter, DifficultyType type, EventQuestData quest)
        {
            var farmDlg = new EventQuestFarmDialog(ReinContexts, chapter.EventQuestChapterId, quest);
            await farmDlg.ShowAsync();

            SetQuestList(chapter, type);
        }
    }
}
