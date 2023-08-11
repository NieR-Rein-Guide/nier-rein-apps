namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct UserGimmickSequence
{
    public long UserId { get; set; }
    public int GimmickSequenceScheduleId { get; set; }
    public int GimmickSequenceId { get; set; }
    public bool IsGimmickSequenceCleared { get; set; }
    public long ClearDateTime { get; set; }

    public void Reset()
    {
        UserId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return UserId != GimmickConstant.kInvalidId;
    }
	}
