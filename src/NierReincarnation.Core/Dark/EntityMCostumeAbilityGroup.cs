using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_ability_group")]
public class EntityMCostumeAbilityGroup
{
    [Key(0)]
    public int CostumeAbilityGroupId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int CostumeAbilityLevelGroupId { get; set; }
}
