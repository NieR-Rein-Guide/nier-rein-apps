using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCharacterRebirthMaterialGroup))]
public class EntityMCharacterRebirthMaterialGroup
{
    [Key(0)]
    public int CharacterRebirthMaterialGroupId { get; set; }

    [Key(1)]
    public int MaterialId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
