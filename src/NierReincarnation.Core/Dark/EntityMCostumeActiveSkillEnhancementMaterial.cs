using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeActiveSkillEnhancementMaterial))]
public class EntityMCostumeActiveSkillEnhancementMaterial
{
    [Key(0)]
    public int CostumeActiveSkillEnhancementMaterialId { get; set; }

    [Key(1)]
    public int SkillLevel { get; set; }

    [Key(2)]
    public int MaterialId { get; set; }

    [Key(3)]
    public int Count { get; set; }

    [Key(4)]
    public int SortOrder { get; set; }
}
