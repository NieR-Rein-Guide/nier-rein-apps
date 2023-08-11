using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_level_group")]
    public class EntityMAbilityLevelGroup
    {
        [Key(0)] // RVA: 0x1DD65A4 Offset: 0x1DD65A4 VA: 0x1DD65A4
        public int AbilityLevelGroupId { get; set; }

        [Key(1)] // RVA: 0x1DD65E4 Offset: 0x1DD65E4 VA: 0x1DD65E4
        public int LevelLowerLimit { get; set; }

        [Key(2)] // RVA: 0x1DD6624 Offset: 0x1DD6624 VA: 0x1DD6624
        public int AbilityDetailId { get; set; }
    }
}
