using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_ability_group")]
public class EntityMCompanionAbilityGroup
{
    [Key(0)]
    public int CompanionAbilityGroupId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }
}
