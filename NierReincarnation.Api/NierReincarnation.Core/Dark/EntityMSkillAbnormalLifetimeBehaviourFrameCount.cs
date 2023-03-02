using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_lifetime_behaviour_frame_count")]
    public class EntityMSkillAbnormalLifetimeBehaviourFrameCount
    {
        [Key(0)]
        public int SkillAbnormalLifetimeBehaviourId { get; set; } // 0x10
        [Key(1)]
        public int FrameCount { get; set; } // 0x14
    }
}