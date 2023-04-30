using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_ability_group")]
    public class EntityMCompanionAbilityGroup
    {
        [Key(0)] // RVA: 0x1DDB4E4 Offset: 0x1DDB4E4 VA: 0x1DDB4E4
        public int CompanionAbilityGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDB524 Offset: 0x1DDB524 VA: 0x1DDB524
        public int SlotNumber { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDB564 Offset: 0x1DDB564 VA: 0x1DDB564
        public int AbilityId { get; set; } // 0x18
    }
}
