using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCharacterBoard
    {
        public static readonly DataOutgameCharacterBoardStatus kDefaultStatus;
        public static readonly int kReleaseRankFirst = 1;
        private static readonly string kProgressFormat = "F0";
        private static readonly int kInvalidCharacterBoardGroupId = 0;
        private static readonly int kInvalidCharacterBoardPanelId = 0;
        private static readonly int kInvalidCharacterBoardUnlockConditionGroupId = 0;
        private static readonly int kPanelReleaseBit1SortOrderBorder = 32;
        private static readonly int kPanelReleaseBit2SortOrderBorder = 64;
        private static readonly int kPanelReleaseBit3SortOrderBorder = 96;
        private static readonly int kPanelReleaseBit4SortOrderBorder = 128;
        private static readonly int kPanelReleaseBitAdjustedValue = 1;
        private static readonly int kCharacterBoardPanelReleaseEffectGroupSortOrder = 1;
        private static readonly int kCharacterCellCharacterBoardAssignmentDataCount = 1;
        private static readonly int kCharacterBoardGroupDefaultIndex = 0;
        private static readonly int kCharacterBoardDetailConditionDefaultIndex = 1;
        private static readonly int kSingleTargetGroupCount = 1;
        private static readonly float kMinProgress = 0;
        private static readonly float kMaxProgress = 1;
        private static readonly int kPanelMaxCount = 128;
        private static readonly int kConditiomMaxCount = 16;
        private static readonly StatusCalculationType kCharacterBoardStatusCalculationType = StatusCalculationType.ADD;

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
