using System.Threading.Tasks;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs
{
    class EventQuestFarmDialog : QuestFarmDialog
    {
        private readonly int _chapterId;
        private readonly EventQuestData _quest;

        public EventQuestFarmDialog(NierReinContexts rein, int chapterId, EventQuestData quest) : 
	        base(rein, quest.Quest.QuestId, quest.QuestName)
        {
            _chapterId = chapterId;
            _quest = quest;
        }

        protected override Task<BattleResult> ExecuteQuest(DataDeck deck)
        {
            return BattleContext.ExecuteEventQuest(_chapterId, _quest, deck);
        }
    }
}
