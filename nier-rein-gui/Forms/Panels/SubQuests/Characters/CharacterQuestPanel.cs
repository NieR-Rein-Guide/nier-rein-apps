using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Characters.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Quests;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters
{
    class CharacterQuestPanel : CharacterListPanel<CharacterQuestChapterData, ClosableQuestListPanel<EventQuestData>>
    {
        private readonly NierReinContexts _rein;

        public CharacterQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<CharacterQuestChapterData> GetCharacters()
        {
            return CalculatorQuest.GetCharacterQuestChapters();
        }

        protected override int GetCharacterId(CharacterQuestChapterData chapter)
        {
            return chapter.CharacterId;
        }

        protected override bool IsChapterLocked(CharacterQuestChapterData chapter)
        {
            return chapter.IsLock;
        }

        protected override ClosableQuestListPanel<EventQuestData> CreateCharacterPanel(CharacterQuestChapterData chapter, IList<CharacterQuestChapterData> chapters)
        {
            return new CharacterQuestListPanel(_rein, chapter, chapters, false);
        }
    }
}
