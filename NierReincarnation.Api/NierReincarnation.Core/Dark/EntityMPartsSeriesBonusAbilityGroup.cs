using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_series_bonus_ability_group")]
    public class EntityMPartsSeriesBonusAbilityGroup
    {
        [Key(0)] // RVA: 0x1DE05EC Offset: 0x1DE05EC VA: 0x1DE05EC
        public int PartsSeriesBonusAbilityGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE062C Offset: 0x1DE062C VA: 0x1DE062C
        public int SetCount { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE066C Offset: 0x1DE066C VA: 0x1DE066C
        public int AbilityId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DE06AC Offset: 0x1DE06AC VA: 0x1DE06AC
        public int AbilityLevel { get; set; } // 0x1C
    }
}
