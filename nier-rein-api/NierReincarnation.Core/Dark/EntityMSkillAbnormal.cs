using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal")]
    public class EntityMSkillAbnormal
    {
        [Key(0)]
        public int SkillAbnormalId { get; set; } // 0x10
        [Key(1)]
        public int SkillAbnormalTypeId { get; set; } // 0x14
        [Key(2)]
        public int AbnormalPolarityType { get; set; } // 0x18
        [Key(3)]
        public int SkillAbnormalLifetimeId { get; set; } // 0x1C
        [Key(4)]
        public int SkillAbnormalBehaviourGroupId { get; set; } // 0x20
    }
}