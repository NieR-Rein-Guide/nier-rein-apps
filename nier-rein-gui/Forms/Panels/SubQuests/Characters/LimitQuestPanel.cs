using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Characters.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Quests;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters
{
    class LimitQuestPanel : CharacterListPanel<DataLimitContentCharacter, LimitQuestBundlePanel>
    {
        private readonly NierReinContexts _rein;

        public LimitQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<DataLimitContentCharacter> GetCharacters()
        {
            return CalculatorLimitContent.CreateDataLimitContentCharacters();
        }

        protected override int GetCharacterId(DataLimitContentCharacter chapter)
        {
            return chapter.Costume.CharacterId;
        }

        protected override bool IsChapterLocked(DataLimitContentCharacter chapter)
        {
            return chapter.IsLock;
        }

        protected override LimitQuestBundlePanel CreateCharacterPanel(DataLimitContentCharacter chapter, IList<DataLimitContentCharacter> chapters)
        {
            return new LimitQuestBundlePanel(_rein, chapter, chapters);
        }
    }
}
