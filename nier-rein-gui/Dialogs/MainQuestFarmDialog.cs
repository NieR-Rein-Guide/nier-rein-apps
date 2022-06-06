using System.Threading.Tasks;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs
{
    class MainQuestFarmDialog : QuestFarmDialog
    {
        private readonly QuestCellData _quest;

        public MainQuestFarmDialog(NierReinContexts rein, QuestCellData quest) : base(rein, quest.Quest.QuestId, quest.QuestName)
        {
            _quest = quest;
        }

        protected override Task<BattleResult> ExecuteQuest(DataDeck deck)
        {
	        return BattleContext.ExecuteMainQuest(_quest, deck);
        }
    }
}
