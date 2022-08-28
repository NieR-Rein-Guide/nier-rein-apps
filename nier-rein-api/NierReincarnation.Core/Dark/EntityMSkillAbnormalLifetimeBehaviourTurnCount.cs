using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_lifetime_behaviour_turn_count")]
    public class EntityMSkillAbnormalLifetimeBehaviourTurnCount
    {
        [Key(0)]
        public int SkillAbnormalLifetimeBehaviourId { get; set; } // 0x10
        [Key(1)]
        public int TurnCount { get; set; } // 0x14
    }
}