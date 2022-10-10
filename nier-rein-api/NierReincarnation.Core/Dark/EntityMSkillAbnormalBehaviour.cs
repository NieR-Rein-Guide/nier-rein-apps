using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour")]
    public class EntityMSkillAbnormalBehaviour
    {
        [Key(0)]
        public int SkillAbnormalBehaviourId { get; set; } // 0x10
        [Key(1)]
        public int AbnormalBehaviourActionType { get; set; } // 0x14
        [Key(2)]
        public int AbnormalBehaviourActivationMethodType { get; set; } // 0x18
        [Key(3)]
        public int AbnormalBehaviourDeactivationMethodType { get; set; } // 0x1C
        [Key(4)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x20
    }
}