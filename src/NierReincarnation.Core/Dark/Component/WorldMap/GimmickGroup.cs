namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickGroup
{
    public int GimmickGroupId { get; set; }

    public int GimmickId { get; set; }

    public void Reset()
    {
        GimmickGroupId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickGroupId != GimmickConstant.kInvalidId;
    }
}
