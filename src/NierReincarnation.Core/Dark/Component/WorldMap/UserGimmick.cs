namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct UserGimmick
{
    public long UserId { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int GimmickSequenceId { get; set; }

    public int GimmickId { get; set; }

    public bool IsGimmickCleared { get; set; }

    public long StartDateTime { get; set; }

    public void Reset()
    {
        UserId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return UserId != GimmickConstant.kInvalidId;
    }
}
