namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickOrnament
{
    public int GimmickOrnamentGroupId { get; set; }
    public int GimmickOrnamentIndex  { get; set; }
    public int GimmickOrnamentViewId  { get; set; }
    public int ChapterId  { get; set; }
    public int BackgroundId  { get; set; }
    public float PositionX  { get; set; }
    public float PositionY  { get; set; }
    public float PositionZ  { get; set; }
    public float Rotation  { get; set; }
    public float Scale  { get; set; }
    public int SortOrder  { get; set; }
    public int OrnamentCount  { get; set; }
    public int IconDifficultyValue  { get; set; }

    public void Reset()
    {
        GimmickOrnamentGroupId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickOrnamentGroupId != GimmickConstant.kInvalidId;
    }
}
