using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_boss_grade_group")]
    public class EntityMBigHuntBossGradeGroup
    {
        [Key(0)] // RVA: 0x1DD61C4 Offset: 0x1DD61C4 VA: 0x1DD61C4
        public int BigHuntBossGradeGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD6204 Offset: 0x1DD6204 VA: 0x1DD6204
        public long NecessaryScore { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DD6244 Offset: 0x1DD6244 VA: 0x1DD6244
        public int AssetGradeIconId { get; set; } // 0x20
    }
}
