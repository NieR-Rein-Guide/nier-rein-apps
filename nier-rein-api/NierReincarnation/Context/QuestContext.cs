using System.Collections.Generic;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Context
{
    public class QuestContext
    {
        internal QuestContext() { }

        public IList<EventQuestChapterData> GetEventChapters()
        {
            return CalculatorQuest.GetEventQuestChapters(EventQuestType.MARATHON, EventQuestType.TOWER, EventQuestType.HUNT, EventQuestType.SPECIAL);
        }

        public IList<EventQuestChapterData> GetDungeonEventChapters()
        {
            return CalculatorQuest.GetEventQuestChapters(EventQuestType.DUNGEON);
        }

        public IList<CharacterQuestChapterData> GetCharacterEventChapters()
        {
            return CalculatorQuest.GetCharacterQuestChapters();
        }

        public IList<CharacterQuestChapterData> GetEndEventChapters()
        {
            return CalculatorQuest.GetEndQuestChapters();
        }

        public IList<EventQuestData> GetEventQuests(int chapterId, DifficultyType difficulty)
        {
            return CalculatorQuest.GenerateEventQuestData(chapterId, difficulty);
        }
    }
}
