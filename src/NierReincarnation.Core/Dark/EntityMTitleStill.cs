using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMTitleStill))]
public class EntityMTitleStill
{
    [Key(0)]
    public int TitleStillId { get; set; }

    [Key(1)]
    public int TitleStillGroupId { get; set; }

    [Key(2)]
    public int ReleaseEvaluateConditionId { get; set; }

    [Key(3)]
    public TitleStillLogoType TitleStillLogoType { get; set; }

    [Key(4)]
    public string AssetName { get; set; }
}
