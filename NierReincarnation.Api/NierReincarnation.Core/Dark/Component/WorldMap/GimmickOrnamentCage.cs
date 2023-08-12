using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickOrnamentCage
{
    public long StartDatetime { get; set; }

    public long EndDatetime { get; set; }

    public long BaseDateTime { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int GimmickSequenceId { get; set; }

    public int NextGimmickSequenceId { get; set; }

    public int GimmickId { get; set; }

    public int GimmickOrnamentGroupId { get; set; }

    public int GimmickOrnamentIndex { get; set; }

    public int GimmickOrnamentViewId { get; set; }

    public int UserGimmickProgressValueBit { get; set; }

    public int IntervalValue { get; set; }

    public int MaxValue { get; set; }

    public int GimmickOrnamentCount { get; set; }

    public float PositionX { get; set; }

    public float PositionY { get; set; }

    public float PositionZ { get; set; }

    public float Rotation { get; set; }

    public float Scale { get; set; }

    public GimmickType GimmickType { get; set; }

    public long SequenceProgressRequireHour { get; set; }

    public long SequenceClearDateTime { get; set; }

    public long SequenceProgressStartDateTime { get; set; }

    public WorldMapGimmickSequenceProgressType SequenceProgressType { get; set; }

    public WorldMapEnableGimmickType EnableGimmickType { get; set; }

    public WorldMapEnableGimmickType EnableGimmickSequenceType { get; set; }

    public void Reset()
    {
        GimmickSequenceScheduleId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickSequenceScheduleId != GimmickConstant.kInvalidId;
    }
}
