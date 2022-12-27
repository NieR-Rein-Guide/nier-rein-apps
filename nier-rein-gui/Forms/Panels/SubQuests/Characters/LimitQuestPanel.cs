using System.Collections.Generic;
using nier_rein_gui.Forms.Panels.SubQuests.Characters.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Characters.LimitQuest;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters
{
    class LimitQuestPanel : ButtonListPanel<DataLimitContentCharacter, LimitQuestBundlePanel>
    {
        private readonly NierReinContexts _rein;

        public LimitQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<DataLimitContentCharacter> GetDataElements()
        {
            return CalculatorLimitContent.CreateDataLimitContentCharacters();
        }

        protected override string GetCaption(DataLimitContentCharacter chapter)
        {
            return CalculatorCharacter.CharacterName(chapter.Costume.CharacterId, true);
        }

        protected override bool IsButtonEnabled(DataLimitContentCharacter chapter)
        {
            return !chapter.IsLock;
        }

        protected override LimitQuestBundlePanel CreatePanel(DataLimitContentCharacter chapter, IList<DataLimitContentCharacter> chapters)
        {
            return new LimitQuestBundlePanel(_rein, chapter, chapters);
        }
    }
}
