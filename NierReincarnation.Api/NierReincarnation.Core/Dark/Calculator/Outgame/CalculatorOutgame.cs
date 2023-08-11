using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorOutgame
{
    public static RarityType PreciousRarityThreshold = RarityType.SS_RARE;
    public static readonly int kMinDifficulty = (int)DifficultyType.NORMAL;
    public static readonly int kMaxDifficulty = (int)DifficultyType.EX_HARD;

    public static readonly List<DifficultyType> kSortedDifficulties = new()
    {
        DifficultyType.NORMAL,
        DifficultyType.HARD,
        DifficultyType.VERY_HARD,
        DifficultyType.EX_HARD
    };

    public static readonly string kGradeIconPrefabKeyPrefix = "ui.rank_icon.prefab.";
    private const string kGradeIconSpriteAssetPathFormat = "ui)search)rank)search_rank_{0}";
    private const string kGradeIconPrefabAssetPathFormat = "ui)rank)rank_icon_{0})rank_icon_{0}";
    private const string kGradeIconLargePrefabAssetPathFormat = "ui)rank)rank_icon_{0}_large)rank_icon_{0}_large";
    private static readonly string kGradeIconPrefabKeyFormat = kGradeIconPrefabKeyPrefix + "{0}";
    private static readonly string kGradeIconLargePrefabKeyFormat = kGradeIconPrefabKeyPrefix + ".large.{0}";

    public static string GetFormatLevelText(int currentLevel, int maxLevel)
    {
        return string.Format(UserInterfaceTextKey.Common.kLevelWithMax.Localize(), currentLevel, maxLevel);
    }

    public static string GetFormatLevelText(int currentLevel)
    {
        return string.Format(UserInterfaceTextKey.Common.kLevel.Localize(), currentLevel);
    }

    public static string GetFormatPermilText(int number)
    {
        return string.Format(UserInterfaceTextKey.Common.kPercent.Localize(), number / 10);
    }

    public static string GetFormatPermilTextWithDecimalPoint(int number)
    {
        return string.Format(UserInterfaceTextKey.Common.kPercent.Localize(), number / 10f);
    }

    public static bool IsEndMomMenuTutorial() => DatabaseDefine.User.EntityIUserTutorialProgressTable
        .TryFindByUserIdAndTutorialType((CalculatorStateUser.GetUserId(), TutorialType.MENU_SECOND), out var _);

    public static bool IsTutorialMenu() => DatabaseDefine.User.EntityIUserTutorialProgressTable
        .TryFindByUserIdAndTutorialType((CalculatorStateUser.GetUserId(), TutorialType.MENU_FIRST), out var _);

    public static string GetStandardMomMenuUnlockText() => CalculatorUnlockCondition.GetMainQuestChapterClearUnlockText(Networking.Config.GetUnlockTutorialMenuChapterId());
}
