using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_remove_abnormal")]
    public class EntityMSkillBehaviourActionRemoveAbnormal
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int TargetPolarityType { get; set; } // 0x14

        [Key(2)]
        public int SkillRemoveAbnormalTargetAbnormalGroupId { get; set; } // 0x18

        [Key(3)]
        public RemoveAbnormalTargetType RemoveAbnormalTargetType { get; set; } // 0x1C

        [Key(4)]
        public int RemoveCountUpper { get; set; } // 0x20

        [Key(5)]
        public int RemoveKindCountUpper { get; set; } // 0x24
    }
}
