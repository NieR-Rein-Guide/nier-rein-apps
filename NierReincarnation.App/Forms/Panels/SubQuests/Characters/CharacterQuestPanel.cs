using NierReincarnation.App.Forms.Panels.SubQuests.Characters.Base;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters
{
    internal class CharacterQuestPanel : ButtonListPanel<CharacterQuestChapterData, ClosableQuestListPanel<EventQuestData>>
    {
        private readonly NierReinContexts _rein;

        public CharacterQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<CharacterQuestChapterData> GetDataElements()
        {
            return CalculatorQuest.GetCharacterQuestChapters();
        }

        protected override string GetText(CharacterQuestChapterData chapter)
        {
            return CalculatorCharacter.CharacterName(chapter.CharacterId, true);
        }

        protected override bool IsButtonEnabled(CharacterQuestChapterData chapter)
        {
            return !chapter.IsLock;
        }

        protected override ClosableQuestListPanel<EventQuestData> CreatePanel(CharacterQuestChapterData chapter, IList<CharacterQuestChapterData> chapters)
        {
            return new CharacterQuestListPanel(_rein, chapter, chapters, false);
        }
    }
}
