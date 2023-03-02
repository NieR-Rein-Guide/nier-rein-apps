using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability")]
    public class EntityMAbility
    {
        [Key(0)] // RVA: 0x1DD62B8 Offset: 0x1DD62B8 VA: 0x1DD62B8
        public int AbilityId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD62F8 Offset: 0x1DD62F8 VA: 0x1DD62F8
        public int AbilityLevelGroupId { get; set; } // 0x14
    }
}
