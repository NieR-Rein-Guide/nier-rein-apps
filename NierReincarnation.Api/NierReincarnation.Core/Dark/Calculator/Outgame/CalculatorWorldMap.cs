using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorWorldMap
{
    private const float kHalf = 2f;

    // CUSTOM: Enumerate all gimmicks of a chapter without checking for clear state
    public static IEnumerable<WorldMapGimmickOutGame> EnumerateAllChapterGimmickDataAsync(int chapterId)
    {
        var result = GimmickManager.Instance.GenerateWorldMapGimmickOutGameAsync(chapterId);
        if (result != WorldMapGimmickModelResultType.Success)
            yield break;

        var worldGimmickCount = GimmickManager.Instance.GetWorldMapGimmickOutGamesCount();
        if (worldGimmickCount <= 0)
            yield break;

        for (var i = 0; i < worldGimmickCount; i++)
        {
            GimmickManager.Instance.GetWorldMapGimmickOutGame(i, out var worldGimmick);
            yield return worldGimmick;
        }
    }

    // CUSTOM: Enumerate all gimmicks of a chapter
    public static IEnumerable<WorldMapGimmickOutGame> EnumerateChapterGimmickDataAsync(int chapterId)
    {
        var unixNow = CalculatorDateTime.UnixTimeNow();
        return EnumerateAllChapterGimmickDataAsync(chapterId).Where(x => IsAvailableGimmick(x, unixNow));
    }

    // CUSTOM: Retrieve all gimmicks without checking for clear state
    public static void GenerateAllChapterGimmickDataAsync(int chapterId, List<WorldMapGimmickOutGame> allGimmickList)
    {
        allGimmickList.Clear();

        var result = GimmickManager.Instance.GenerateWorldMapGimmickOutGameAsync(chapterId);
        if (result != WorldMapGimmickModelResultType.Success)
            return;

        var worldGimmickCount = GimmickManager.Instance.GetWorldMapGimmickOutGamesCount();
        if (worldGimmickCount <= 0)
            return;

        for (var i = 0; i < worldGimmickCount; i++)
        {
            GimmickManager.Instance.GetWorldMapGimmickOutGame(i, out var worldGimmick);
            allGimmickList.Add(worldGimmick);
        }
    }

    public static void GenerateChapterGimmickDataAsync(int chapterId, List<WorldMapGimmickOutGame> gimmickList, List<WorldMapGimmickOutGame> allGimmickList)
    {
        gimmickList.Clear();

        var result = GimmickManager.Instance.GenerateWorldMapGimmickOutGameAsync(chapterId);
        if (result != WorldMapGimmickModelResultType.Success)
            return;

        var worldGimmickCount = GimmickManager.Instance.GetWorldMapGimmickOutGamesCount();
        if (worldGimmickCount <= 0)
            return;

        var unixNow = CalculatorDateTime.UnixTimeNow();
        for (var i = 0; i < worldGimmickCount; i++)
        {
            GimmickManager.Instance.GetWorldMapGimmickOutGame(i, out var worldGimmick);
            allGimmickList.Add(worldGimmick);

            var isAvailable = IsAvailableGimmick(worldGimmick, unixNow);
            if (isAvailable)
                gimmickList.Add(worldGimmick);
        }
    }

    public static bool IsAvailableGimmick(WorldMapGimmickOutGame gimmickOutGame, long nowTime)
    {
        if (0 >= gimmickOutGame.BaseDateTime || gimmickOutGame.StartDatetime > nowTime || nowTime >= gimmickOutGame.EndDatetime)
            return false;

        var isCleared = IsClearedGimmick(gimmickOutGame);
        if (isCleared)
            return false;

        if ((gimmickOutGame.GimmickType == GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM ||
             gimmickOutGame.GimmickType == GimmickType.CAGE_INTERVAL_DROP_ITEM) &&
            gimmickOutGame.GetAvailableIntervalGimmickCount(nowTime) == 0)
            return false;

        var isAvailable = IsAvailableSequenceProgressTime(gimmickOutGame, nowTime);
        return isAvailable && (gimmickOutGame.GimmickType != GimmickType.MAP_ONLY_HIDE_OBELISK ||
                               gimmickOutGame.EnableGimmickType != WorldMapEnableGimmickType.NotStart);
    }

    private static bool IsClearedGimmick(WorldMapGimmickOutGame worldMapGimmickOutGame)
    {
        if (worldMapGimmickOutGame.GimmickOrnamentCount <= 0)
            return false;

        var p = Math.Pow(kHalf, worldMapGimmickOutGame.GimmickOrnamentCount) - 1;
        return worldMapGimmickOutGame.UserGimmickProgressValueBit == p;
    }

    private static bool IsAvailableSequenceProgressTime(WorldMapGimmickOutGame gimmickOutGame, long nowTime)
    {
        switch (gimmickOutGame.SequenceProgressType)
        {
            case WorldMapGimmickSequenceProgressType.RequireHourAndStartDateTime:
                return gimmickOutGame.IsAvailableGimmickSequence(nowTime) && gimmickOutGame.IsAvailableGimmickSequenceStartDateTime(nowTime);

            case WorldMapGimmickSequenceProgressType.StartDateTimeOnly:
                return gimmickOutGame.IsAvailableGimmickSequenceStartDateTime(nowTime);

            case WorldMapGimmickSequenceProgressType.RequireHourOnly:
                return gimmickOutGame.IsAvailableGimmickSequence(nowTime);

            default:
                return false;
        }
    }

    public static bool IsIntervalDropItemType(GimmickType gimmickType)
    {
        if (gimmickType == GimmickType.CAGE_INTERVAL_DROP_ITEM)
            return true;

        return gimmickType == GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM;
    }

    public static bool IsReleasedHideObelisk(long userId, int gimmickId, int gimmickOrnamentIndex)
    {
        var masterQuest = GetHideObeliskQuest(gimmickId, gimmickOrnamentIndex);
        if (masterQuest == null)
            return false;

        return CalculatorQuest.IsUnlockedQuest(masterQuest.QuestReleaseConditionListId, userId);
    }

    // CUSTOM: Get quest data for HIDE_OBELISK gimmicks
    public static EntityMQuest GetHideObeliskQuest(int gimmickId, int gimmickOrnamentIndex)
    {
        var table = DatabaseDefine.Master.EntityMGimmickExtraQuestTable;
        var gimmickQuest = table.FindByGimmickIdAndGimmickOrnamentIndex((gimmickId, gimmickOrnamentIndex));
        if (gimmickQuest == null)
            return null;

        var table1 = DatabaseDefine.Master.EntityMExtraQuestGroupTable;
        var questGroup = table1.All.FirstOrDefault(x => x.ExtraQuestId == gimmickQuest.ExtraQuestId);

        var questId = gimmickQuest.ExtraQuestId;
        if (questGroup != null)
            questId = questGroup.QuestId;

        var table2 = DatabaseDefine.Master.EntityMQuestTable;
        return table2.FindByQuestId(questId);
    }
}
