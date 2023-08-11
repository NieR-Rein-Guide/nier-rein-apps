namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickInterval
{
    public int GimmickId { get; set; }
    public int IntervalValue  { get; set; }
    public int MaxValue  { get; set; }
    public int InitialValue  { get; set; }

    public void Reset()
    {
        GimmickId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickId != GimmickConstant.kInvalidId;
    }
}
