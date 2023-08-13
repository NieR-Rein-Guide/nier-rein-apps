namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickSequenceRewardGroup
{
    public int GimmickSequenceRewardGroupId { get; set; }

    public void Reset()
    {
        GimmickSequenceRewardGroupId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickSequenceRewardGroupId != GimmickConstant.kInvalidId;
    }
}
