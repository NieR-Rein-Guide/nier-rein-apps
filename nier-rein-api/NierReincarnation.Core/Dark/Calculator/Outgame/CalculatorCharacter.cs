using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Localization;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCharacter
    {
        private static readonly int kInvalidQuestId; // 0x0

        public static string GetCharacterName(int characterId)
        {
            return CharacterName(characterId);
        }

        // CUSTOM: Ignore display switch for character name
        public static string CharacterName(int characterId, bool ignoreDisplaySwitch = false)
        {
            var userId = CalculatorStateUser.GetUserId();

            if (!ignoreDisplaySwitch)
            {
                var displaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);
                if (displaySwitch != null)
                {
                    var clearCond = displaySwitch.DisplayConditionClearQuestId;
                    if (CalculatorQuest.IsClearQuest(clearCond, userId))
                        return GetName(displaySwitch.NameCharacterTextId);
                }
            }

            var character = CalculatorMasterData.GetEntityMCharacter(characterId);
            if (character == null)
                return null;

            return GetName(character.NameCharacterTextId);
        }

        public static int GetEndWeaponId(int characterId)
        {
            var table = DatabaseDefine.Master.EntityMCharacterTable;
            return table.FindByCharacterId(characterId).EndWeaponId;
        }

        private static string GetName(int nameTextId)
        {
            if (nameTextId == 0)
                return null;

            return $"character.name.{nameTextId}".Localize();
        }
    }
}
