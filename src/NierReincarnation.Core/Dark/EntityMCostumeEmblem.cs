using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_emblem")]
public class EntityMCostumeEmblem
{
    [Key(0)]
    public int CostumeEmblemAssetId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }
}
