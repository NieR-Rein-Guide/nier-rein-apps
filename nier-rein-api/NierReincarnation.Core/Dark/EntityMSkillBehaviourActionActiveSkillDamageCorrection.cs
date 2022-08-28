using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_active_skill_damage_correction")]
    public class EntityMSkillBehaviourActionActiveSkillDamageCorrection
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int CorrectionValuePermil { get; set; } // 0x14
    }
}