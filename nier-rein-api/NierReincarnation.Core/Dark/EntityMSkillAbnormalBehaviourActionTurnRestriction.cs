using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_turn_restriction")]
    public class EntityMSkillAbnormalBehaviourActionTurnRestriction
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int TurnRestrictionProbabilityPermil { get; set; } // 0x14
        [Key(2)]
        public int AbnormalBehaviourTurnRestrictionSkillType { get; set; } // 0x18
    }
}