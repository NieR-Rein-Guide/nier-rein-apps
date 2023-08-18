using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorCharacterBoard
{
    public static readonly DataOutgameCharacterBoardStatus kDefaultStatus;
    public static readonly int kReleaseRankFirst = 1;
    public const string kProgressFormat = "F0";
    private static readonly int kInvalidCharacterBoardGroupId;
    private static readonly int kInvalidCharacterBoardPanelId;
    private static readonly int kInvalidCharacterBoardUnlockConditionGroupId;
    private const int kPanelReleaseBit1SortOrderBorder = 32;
    private const int kPanelReleaseBit2SortOrderBorder = 64;
    private const int kPanelReleaseBit3SortOrderBorder = 96;
    private const int kPanelReleaseBit4SortOrderBorder = 128;
    private const int kPanelReleaseBitAdjustedValue = 1;
    private const int kCharacterBoardPanelReleaseEffectGroupSortOrder = 1;
    private const int kCharacterCellCharacterBoardAssignmentDataCount = 1;
    private static readonly int kCharacterBoardGroupDefaultIndex;
    private const int kCharacterBoardDetailConditionDefaultIndex = 1;
    private const int kSingleTargetGroupCount = 1;
    private static readonly float kMinProgress;
    private const float kMaxProgress = 1;
    private const int kPanelMaxCount = 128;
    private const int kConditiomMaxCount = 16;
    private const StatusCalculationType kCharacterBoardStatusCalculationType = StatusCalculationType.ADD;

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
        if (boardAbilities.Count == 0)
            return null;

        return boardAbilities.ConvertAll(ba => CalculatorAbility.CreateDataAbility(ba.AbilityId, ba.Level, 0));
    }
}
