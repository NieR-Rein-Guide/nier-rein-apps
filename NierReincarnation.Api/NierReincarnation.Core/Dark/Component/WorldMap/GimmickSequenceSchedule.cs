namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickSequenceSchedule
{
    public int GimmickSequenceScheduleId { get; set; }
    public int FirstGimmickSequenceId { get; set; }
    public long StartDatetime { get; set; }
    public long EndDatetime { get; set; }

    public void Reset()
    {
        GimmickSequenceScheduleId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickSequenceScheduleId != GimmickConstant.kInvalidId;
    }
}
