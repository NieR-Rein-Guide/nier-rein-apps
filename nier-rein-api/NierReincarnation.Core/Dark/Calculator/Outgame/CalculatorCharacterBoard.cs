using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCharacterBoard
    {
        public static readonly DataOutgameCharacterBoardStatus kDefaultStatus; // 0x0
        public static readonly int kReleaseRankFirst = 1; // 0x18
        private static readonly string kProgressFormat = "F0"; // 0x20
        private static readonly int kInvalidCharacterBoardGroupId = 0; // 0x28
        private static readonly int kInvalidCharacterBoardPanelId = 0; // 0x2C
        private static readonly int kInvalidCharacterBoardUnlockConditionGroupId = 0; // 0x30
        private static readonly int kPanelReleaseBit1SortOrderBorder = 32; // 0x34
        private static readonly int kPanelReleaseBit2SortOrderBorder = 64; // 0x38
        private static readonly int kPanelReleaseBit3SortOrderBorder = 96; // 0x3C
        private static readonly int kPanelReleaseBit4SortOrderBorder = 128; // 0x40
        private static readonly int kPanelReleaseBitAdjustedValue = 1; // 0x44
        private static readonly int kCharacterBoardPanelReleaseEffectGroupSortOrder = 1; // 0x48
        private static readonly int kCharacterCellCharacterBoardAssignmentDataCount = 1; // 0x4C
        private static readonly int kCharacterBoardGroupDefaultIndex = 0; // 0x50
        private static readonly int kCharacterBoardDetailConditionDefaultIndex = 1; // 0x54
        private static readonly int kSingleTargetGroupCount = 1; // 0x58
        private static readonly float kMinProgress = 0; // 0x5C
        private static readonly float kMaxProgress = 1; // 0x60
        private static readonly int kPanelMaxCount = 128; // 0x64
        private static readonly int kConditiomMaxCount = 16; // 0x68
        private static readonly StatusCalculationType kCharacterBoardStatusCalculationType = StatusCalculationType.ADD; // 0x6C

        public static List<DataAbilityStatus> CreateCharacterBoardAbilityStatusList(long userId, int characterId)
        {
            var boardAbilities = CalculatorDataCharacterBoard.CreateUserCharacterBoardAbilities(userId, characterId);
            if (boardAbilities == null)
                return null;

            var result = new List<DataAbilityStatus>();
            foreach (var ability in boardAbilities)
            {
                var dataAbility = CalculatorAbility.CreateDataAbility(ability.AbilityId, ability.Level, 0);
                result.AddRange(dataAbility.AbilityStatusList);
            }

            return result;
        }

        public static List<DataCharacterBoardStatus> CreateCharacterBoardStatusList(long userId, int characterId)
        {
            var result = new List<DataCharacterBoardStatus>();
            CalculatorDataCharacterBoard.CreateCharacterBoardStatusList(userId, characterId, result);

            return result;
        }

        public static List<DataAbility> CreateCharacterBoardAbilityList(long userId, int characterId)
        {
            var boardAbilities = CalculatorDataCharacterBoard.CreateUserCharacterBoardAbilities(userId, characterId);
            if (boardAbilities.Count <= 0)
                return null;

            return boardAbilities.Select(ba => CalculatorAbility.CreateDataAbility(ba.AbilityId, ba.Level, 0)).ToList();
        }
    }
}
