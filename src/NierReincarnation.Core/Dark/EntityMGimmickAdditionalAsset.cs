using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMGimmickAdditionalAsset))]
public class EntityMGimmickAdditionalAsset
{
    [Key(0)]
    public int GimmickId { get; set; }

    [Key(1)]
    public string GimmickTexturePath { get; set; }
}
