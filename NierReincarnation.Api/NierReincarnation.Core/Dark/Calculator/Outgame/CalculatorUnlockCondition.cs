using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System;
using System.Linq;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorUnlockCondition
{
    public static bool IsUnlock(UnlockConditionType unlockConditionType, int conditionValue, long userId)
    {
        return unlockConditionType != UnlockConditionType.QUEST_CLEAR || CalculatorQuest.IsClearQuest(conditionValue, userId);
    }

    public static bool IsUnlockGacha(GachaUnlockConditionType gachaUnlockConditionType, int conditionValue)
    {
        if (gachaUnlockConditionType == GachaUnlockConditionType.MAIN_FUNCTION_RELEASED)
        {
            return IsUnlockFunction((MainFunctionType)conditionValue);
        }
        else if (gachaUnlockConditionType == GachaUnlockConditionType.MAIN_QUEST_CLEAR)
        {
            return CalculatorQuest.IsClearQuest(conditionValue, CalculatorStateUser.GetUserId());
        }
        else if (gachaUnlockConditionType == GachaUnlockConditionType.NONE)
        {
            return true;
        }

        return false;
    }

    public static ValueTuple<bool, string> GetExploreUnlockCondition(int exploreId, ExploreUnlockConditionType conditionType, int value, long userId, long startUnixTime)
    {
        if (!CalculatorDateTime.IsPassed(startUnixTime))
        {
            return (false, UserInterfaceTextKey.Common.kQuestionMarksKey.Localize());
        }

        if (conditionType == ExploreUnlockConditionType.EXPLORE_SCORE_OVER_IN_SAME_GROUP_AND_ONE_LOW_DIFFICULTY)
        {
            var exploreDifficultyType = CalculatorSearch.GetSameExploreGroupOneLowDifficultyExploreInfo(exploreId);

            if (CalculatorSearch.GetMaxScore(userId, exploreDifficultyType.Item1) >= value)
            {
                return (true, string.Empty);
            }

            return (false, UserInterfaceTextKey.Search.kUnlockHighScore.LocalizeWithParams(CalculatorSearch.GetSearchMinigameName(exploreDifficultyType.Item1),
                UserInterfaceTextKey.Quest.kQuestDifficulty.LocalizeWithParams((int)exploreDifficultyType.Item2), value));
        }

        if (conditionType == ExploreUnlockConditionType.MAIN_QUEST_CLEAR && CalculatorQuest.IsClearQuest(value, userId))
        {
            return (true, string.Empty);
        }

        return (true, GetMainQuestUnlockGenericText());
    }

    public static ValueTuple<bool, string> IsUnlockSearch()
    {
        var exploreUnlockCondition = CalculatorSearch.GetEntityMExploreUnlockConditionByExploreId(CalculatorSearch.GetFirstExploreId());

        if (exploreUnlockCondition != null)
        {
            return GetExploreUnlockCondition(CalculatorSearch.GetFirstExploreId(), exploreUnlockCondition.ExploreUnlockConditionType,
                exploreUnlockCondition.ConditionValue, CalculatorStateUser.GetUserId(), 0);
        }

        return (false, string.Empty);
    }

    public static bool IsUnlockLibrary()
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockMap() => CalculatorQuest.IsClearQuest(Config.GetUnlockMapQuestId(), CalculatorStateUser.GetUserId());

    public static bool IsUnlockEndContents()
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockLimitContent()
    {
        var eventQuestUnlockCondition = DatabaseDefine.Master.EntityMEventQuestUnlockConditionTable
            .FindByEventQuestTypeAndUnlockConditionType((EventQuestType.LIMIT_CONTENT, UnlockConditionType.QUEST_CLEAR))
            .ElementAtOrDefault(0);

        return eventQuestUnlockCondition != null && CalculatorQuest.IsClearQuest(eventQuestUnlockCondition.ConditionValue, CalculatorStateUser.GetUserId());
    }

    public static bool IsUnlockSubQuest()
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockPvp() => CalculatorQuest.IsClearQuest(Config.GetUnlockPvpQuestId(), CalculatorStateUser.GetUserId());

    public static bool IsUnlockBigHunt() => CalculatorQuest.IsClearQuest(Config.GetUnlockBigHuntQuestId(), CalculatorStateUser.GetUserId());

    public static bool IsUnlockDailyGacha()
    {
        return CalculatorQuest.IsClearQuest(questId: Config.GetUnlockDailyGachaId(), userId: CalculatorStateUser.GetUserId());
    }

    public static bool IsUnlockDailyQuest() => CalculatorQuest.IsClearQuest(questId: Config.GetUnlockDailyQuestId(), userId: CalculatorStateUser.GetUserId());

    public static bool IsUnlockGuerrillaAndDayOfTheWeek()
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockCharacterViewer() => CalculatorQuest.IsClearQuest(Config.GetUnlockCharacterViewerQuestId(), userId: CalculatorStateUser.GetUserId());

    public static DifficultyType GetUnlockedDifficultyType()
    {
        if (CalculatorQuest.IsClearQuest(Config.GetUnlockVeryHardQuestQuestId(), CalculatorStateUser.GetUserId()))
        {
            return DifficultyType.VERY_HARD;
        }

        if (CalculatorQuest.IsClearQuest(Config.GetUnlockHardQuestQuestId(), CalculatorStateUser.GetUserId()))
        {
            return DifficultyType.HARD;
        }

        return DifficultyType.NORMAL;
    }

    public static string GetMainQuestUnlockGenericText() => UserInterfaceTextKey.Unlock.kUnlockReachedMainQuest.Localize();

    public static string GetMainQuestChapterClearUnlockText(int chapterId) => UserInterfaceTextKey.Common.kUnlockTiming.LocalizeWithParams(CalculatorQuest.GetClearChapterText(chapterId));

    public static string GetMainQuestChapterClearUnlockText(string chapterNumberName) => UserInterfaceTextKey.Common.kUnlockTiming.LocalizeWithParams(CalculatorQuest.GetClearChapterText(chapterNumberName));

    public static string GetQuestClearUnlockText(int questId) => CalculatorQuest.GetQuestClearUnlockText(questId);

    public static bool IsUnlockOrganizationDressupCostume() => IsUnlock(UnlockConditionType.QUEST_CLEAR, Config.GetUnlockDressupCostumeQuestId(), CalculatorStateUser.GetUserId());

    public static bool IsUnlockOrganizationMemory() => IsUnlock(UnlockConditionType.QUEST_CLEAR, Config.GetUnlockPartsQuestId(), CalculatorStateUser.GetUserId());

    public static bool IsUnlockOrganizationCompanion() => DatabaseDefine.User.EntityIUserTutorialProgressTable.TryFindByUserIdAndTutorialType((CalculatorStateUser.GetUserId(), TutorialType.COMPANION), out var _);

    public static bool IsUnlockChapterGachaLabelType() => !CalculatorOutgame.IsTutorialMenu();

    public static bool IsUnlockCharacterBoard() => CalculatorQuest.IsClearQuest(Config.GetUnlockCharacterBoardQuestId(), CalculatorStateUser.GetUserId());
    public static bool IsUnlockCharacterBoardWithNeedTutorial() => IsUnlockCharacterBoard();
    public static bool IsUnlockBigHuntBoard(long userId) => CalculatorEvaluateCondition.EvaluateCondition(userId, Config.GetUnlockBigHuntBoardEvaluateConditionId());

    public static bool IsUnlockGachaExchange() => !CalculatorOutgame.IsTutorialMenu();

    public static bool IsUnlockFunction(MainFunctionType mainFunctionType)
    {
        return mainFunctionType switch
        {
            MainFunctionType.PVP => IsUnlockPvp(),
            MainFunctionType.EVENT_QUEST => IsUnlockSubQuest(),
            MainFunctionType.EXPLORATION => IsUnlockSearch().Item1,
            MainFunctionType.END_CONTENTS => IsUnlockEndContents(),
            MainFunctionType.LIBRARY => IsUnlockLibrary(),
            MainFunctionType.ENHANCE_COMPANION => IsUnlockOrganizationCompanion(),
            MainFunctionType.ENHANCE_PARTS => IsUnlockOrganizationMemory(),
            MainFunctionType.BIG_HUNT => IsUnlockBigHunt(),
            MainFunctionType.CHARACTER_BOARD => IsUnlockCharacterBoard(),
            MainFunctionType.WORLD_MAP => IsUnlockMap(),
            MainFunctionType.DRESSUP_COSTUME => IsUnlockOrganizationDressupCostume(),
            MainFunctionType.LIMIT_CONTENT => IsUnlockLimitContent(),
            MainFunctionType.CHARACTER_VIEWER => IsUnlockCharacterViewer(),
            _ => true
        };
    }

    public static string GetUnlockText(MainFunctionType mainFunctionType)
    {
        return mainFunctionType switch
        {
            MainFunctionType.PVP => GetQuestClearUnlockText(Config.GetUnlockPvpQuestId()),
            MainFunctionType.EVENT_QUEST or MainFunctionType.EXPLORATION or MainFunctionType.LIBRARY or MainFunctionType.ENHANCE_COMPANION => GetMainQuestUnlockGenericText(),
            MainFunctionType.ENHANCE_PARTS => GetQuestClearUnlockText(Config.GetUnlockPartsQuestId()),
            MainFunctionType.BIG_HUNT => GetQuestClearUnlockText(Config.GetUnlockBigHuntQuestId()),
            MainFunctionType.CHARACTER_BOARD => GetQuestClearUnlockText(Config.GetUnlockCharacterBoardQuestId()),
            MainFunctionType.WORLD_MAP => GetQuestClearUnlockText(Config.GetUnlockMapQuestId()),
            MainFunctionType.DRESSUP_COSTUME => GetQuestClearUnlockText(Config.GetUnlockDressupCostumeQuestId()),
            MainFunctionType.CHARACTER_VIEWER => GetQuestClearUnlockText(Config.GetUnlockCharacterViewerQuestId()),
            _ => string.Empty
        };
    }

    public static bool TryGetUnlockDifficultyTypeWithQuestId(int releaseQuestId, out DifficultyType releaseDifficultyType)
    {
        throw new NotImplementedException();
    }

    public static bool TryGetUnlockDifficultyTypeSubQuestWithQuestId(int releaseQuestId, out DifficultyType releaseDifficultyType)
    {
        throw new NotImplementedException();
    }

    public static DifficultyType GetUnlockMaxDifficultyTypeByChapterId(int chapterId)
    {
        throw new NotImplementedException();
    }

    public static bool IsUnlockQuestSkip() => CalculatorQuest.IsClearQuest(Config.GetUnlockQuestSkipQuestId(), CalculatorStateUser.GetUserId());
}
