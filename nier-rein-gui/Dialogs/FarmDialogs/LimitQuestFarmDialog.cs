using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    class LimitQuestFarmDialog : QuestFarmDialog<EventQuestData>
    {
        public LimitQuestFarmDialog(NierReinContexts rein, IList<EventQuestData> questList, EventQuestData quest) :
            base(rein, questList, quest, DeckType.RESTRICTED_LIMIT_CONTENT_QUEST)
        {
        }

        protected override int GetQuestId(EventQuestData data)
        {
            return data.Quest.QuestId;
        }

        protected override string GetQuestName(EventQuestData data)
        {
            return data.QuestName;
        }

        protected override bool IsQuestLocked(EventQuestData data)
        {
            return CalculatorQuest.IsQuestLocked(data.Quest.QuestId);
        }

        protected override void SetLock(EventQuestData data, bool isLock)
        {
            data.IsLock = isLock;
        }

        protected override IEnumerable<DataDeckInfo> EnumerateDecks(IList<EventQuestData> quests, EventQuestData quest, DeckType deckType)
        {
            var index = quests.IndexOf(quest);
            return base.EnumerateDecks(quests, quest, deckType).Where(x => x.UserDeckNumber == 101 + index);
        }

        protected override Task<BattleResult> ExecuteQuest(EventQuestData quest, DataDeck deck)
        {
            return BattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);
        }
    }
}
