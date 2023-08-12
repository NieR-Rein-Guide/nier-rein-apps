using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct WorldMapGimmickOutGame
{
    public long StartDatetime { get; set; }

    public long EndDatetime { get; set; }

    public long GimmickStartDateTime { get; set; }

    public long BaseDateTime { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int NextGimmickSequenceId { get; set; }

    public int GimmickGroupId { get; set; }

    public int ChapterId { get; set; }

    public int UserGimmickProgressValueBit { get; set; }

    public int GimmickOrnamentCount { get; set; }

    public int IntervalValue { get; set; }

    public int MaxValue { get; set; }

    public float PositionX { get; set; }

    public float PositionY { get; set; }

    public float PositionZ { get; set; }

    public int IconDifficultyValue { get; set; }

    public int GimmickOrnamentIndex { get; set; }

    public int GimmickId { get; set; }

    public GimmickType GimmickType { get; set; }

    public long SequenceProgressRequireHour { get; set; }

    public long SequenceClearDateTime { get; set; }

    public long SequenceProgressStartDateTime { get; set; }

    public WorldMapGimmickSequenceProgressType SequenceProgressType { get; set; }

    public WorldMapEnableGimmickType EnableGimmickType { get; set; }

    public WorldMapEnableGimmickType EnableGimmickSequenceType { get; set; }

    // CUSTOM
    public int GimmickSequenceId { get; set; }

    public FlowType GimmickFlowType { get; set; }

    public int CageOrnamentId { get; set; }

    public void Reset()
    {
        BaseDateTime = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return (int)BaseDateTime != GimmickConstant.kInvalidId;
    }

    public int GetAvailableIntervalGimmickCount(long nowUnixTimeMilliSeconds)
    {
        var isInterval = CalculatorWorldMap.IsIntervalDropItemType(GimmickType);
        if (!isInterval && IntervalValue == 0)
            return GimmickConstant.kInvalidCount;

        //var isEndPortal = CalculatorForceOperation.IsEndPortalCageDropItem();
        //if (!isEndPortal)
        //    return !ExistNextPlayableSceneForPortal() && GimmickType == GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM;

        var baseMins = BaseDateTime / GimmickConstant.kMilliSecondsToMinutesTimes;
        var nowMins = nowUnixTimeMilliSeconds / GimmickConstant.kMilliSecondsToMinutesTimes;

        var parts = 0;
        if (IntervalValue != 0)
            parts = (int)((nowMins - baseMins) / IntervalValue);

        return parts <= MaxValue ? parts : MaxValue;
    }

    public bool IsAvailableGimmickSequence(long nowUnixTimeMilliSeconds)
    {
        return SequenceProgressRequireHour + SequenceClearDateTime <= nowUnixTimeMilliSeconds;
    }

    public bool IsAvailableGimmickSequenceStartDateTime(long nowUnixTimeMilliSeconds)
    {
        return SequenceProgressStartDateTime <= nowUnixTimeMilliSeconds;
    }
}
