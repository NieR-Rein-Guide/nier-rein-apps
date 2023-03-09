using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_boss_grade_group_attribute")]
    public class EntityMBigHuntBossGradeGroupAttribute
    {
        [Key(0)]
        public int AttributeType { get; set; } // 0x10
        [Key(1)]
        public int BigHuntBossGradeGroupId { get; set; } // 0x14
    }
}