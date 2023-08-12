using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Types;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorSearch
{
    private const int kFirstExploreId = 1;
    private const int kInvalidExploreId = 0;

    public static int GetFirstExploreId() => kFirstExploreId;

    public static bool IsCoolTime(long userId)
    {
        throw new NotImplementedException();
    }

    public static int PlayingExploreId(long userId) => (GetEntityIUserExplore(userId)?.PlayingExploreId) ?? 0;

    public static DateTimeOffset SearchAbleTime(long userId)
    {
        var userExplore = GetEntityIUserExplore(userId);

        return userExplore != null
            ? CalculatorDateTime.FromUnixTime(userExplore.LatestPlayDatetime).AddMinutes(Config.GetExplorePlayIntervalMinute()).ToLocalTime()
            : DateTimeOffset.Now;
    }

    public static void AddLocalPushSchedule()
    {
        throw new NotImplementedException();
    }

    //public static SearchGameContentData[] CreateSearchGameDataList(long userId)
    //{
    //    throw new NotImplementedException();
    //}

    //private static SearchGameContentData CreateSearchGameData(long userId, EntityMExplore entityMExplore)
    //{
    //    throw new NotImplementedException();
    //}

    private static bool IsValidMiniGame(MiniGames miniGameType) => miniGameType < MiniGames.FlyingMom;

    public static int GetMaxScore(long userId, int exploreId) => GetEntityIUserExploreScore(userId, exploreId)?.MaxScore ?? 0;

    public static EntityMExploreUnlockCondition GetEntityMExploreUnlockConditionByExploreId(int exploreId) => GetEntityMExploreUnlockCondition(GetEntityMExplore(exploreId).ExploreUnlockConditionId);

    public static string GetSearchMinigameName(int exploreId) => $"search.minigame.name.{exploreId:D2}".Localize();

    public static ValueTuple<int, DifficultyType> GetSameExploreGroupOneLowDifficultyExploreInfo(int exploreId)
    {
        var exploreGroup = GetEntityMExploreGroup(exploreId);

        if (exploreGroup == null)
        {
            return (kInvalidExploreId, DifficultyType.UNKNOWN);
        }

        var lowestDifficulty = GetOneLowDifficultyType(exploreGroup.DifficultyType);
        var exploreGroupLowestDifficulty = GetEntityMExploreGroup(exploreId, lowestDifficulty);

        return exploreGroupLowestDifficulty != null
            ? (exploreGroupLowestDifficulty.ExploreId, exploreGroupLowestDifficulty.DifficultyType)
            : (kInvalidExploreId, DifficultyType.UNKNOWN);
    }

    public static ValueTuple<MiniGames, DifficultyType> GetMiniGameInfo(int exploreId)
    {
        var exploreGroup = GetEntityMExploreGroup(exploreId);

        return ((MiniGames)exploreGroup.ExploreGroupId, exploreGroup.DifficultyType);
    }

    public static DifficultyType GetMiniGameDifficultyType(int exploreId) => GetEntityMExploreGroup(exploreId).DifficultyType;

    public static bool IsUnlockAnyMiniGame(int exploreId, int score, int beforeHighScore, out List<int> unlockExploreIds)
    {
        unlockExploreIds = new();
        RangeView<EntityMExplore> explorations = GetEntityMExploreList();

        if (explorations.Count == 0) return false;

        foreach (var exploration in explorations)
        {
            var unlockCondition = GetEntityMExploreUnlockCondition(exploration.ExploreUnlockConditionId);

            if (unlockCondition.ExploreUnlockConditionType == ExploreUnlockConditionType.EXPLORE_SCORE_OVER_IN_SAME_GROUP_AND_ONE_LOW_DIFFICULTY)
            {
                var explorationPreviousDifficultyInfo = GetSameExploreGroupOneLowDifficultyExploreInfo(exploreId);

                if (unlockCondition.ConditionValue <= score && unlockCondition.ConditionValue > beforeHighScore && explorationPreviousDifficultyInfo.Item1 == exploreId)
                {
                    unlockExploreIds.Add(exploration.ExploreId);
                }
            }
        }

        return unlockExploreIds.Count > 0;
    }

    private static DifficultyType GetOneLowDifficultyType(DifficultyType difficultyType)
    {
        if (difficultyType == DifficultyType.UNKNOWN) return DifficultyType.UNKNOWN;

        return difficultyType > DifficultyType.NORMAL
            ? difficultyType - 1
            : DifficultyType.NORMAL;
    }

    private static EntityMExploreGroup GetEntityMExploreGroup(int exploreId) => DatabaseDefine.Master.EntityMExploreGroupTable.FindByExploreId(exploreId).FirstOrDefault();

    private static EntityMExploreGroup GetEntityMExploreGroup(int exploreGroupId, DifficultyType difficultyType) => DatabaseDefine.Master.EntityMExploreGroupTable.FindByExploreGroupIdAndDifficultyType((exploreGroupId, difficultyType));

    private static EntityMExplore GetEntityMExplore(int exploreId) => DatabaseDefine.Master.EntityMExploreTable.FindByExploreId(exploreId);

    private static RangeView<EntityMExplore> GetEntityMExploreList() => DatabaseDefine.Master.EntityMExploreTable.FindRangeByExploreId(int.MinValue, int.MaxValue, true);

    private static EntityMExploreUnlockCondition GetEntityMExploreUnlockCondition(int exploreUnlockConditionId) => DatabaseDefine.Master.EntityMExploreUnlockConditionTable.FindByExploreUnlockConditionId(exploreUnlockConditionId);

    private static EntityMExploreGradeScore GetEntityMExploreGradeScore(int exploreId, int highScore) => DatabaseDefine.Master.EntityMExploreGradeScoreTable.FindClosestByExploreIdAndNecessaryScore((exploreId, highScore), true);

    private static EntityMExploreGradeAsset GetEntityMExploreGradeAsset(int exploreGradeId) => DatabaseDefine.Master.EntityMExploreGradeAssetTable.FindByExploreGradeId(exploreGradeId);

    private static EntityIUserExplore GetEntityIUserExplore(long userId) => DatabaseDefine.User.EntityIUserExploreTable.FindByUserId(userId);

    private static EntityIUserExploreScore GetEntityIUserExploreScore(long userId, int exploreId) => DatabaseDefine.User.EntityIUserExploreScoreTable.FindByUserIdAndExploreId((userId, exploreId));
}
