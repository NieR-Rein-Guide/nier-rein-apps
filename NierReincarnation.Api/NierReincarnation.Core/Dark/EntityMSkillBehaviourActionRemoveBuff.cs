using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_remove_buff")]
    public class EntityMSkillBehaviourActionRemoveBuff
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int RemoveCount { get; set; } // 0x14

        [Key(2)]
        public BuffType BuffType { get; set; } // 0x18

        [Key(3)]
        public SkillRemoveBuffFilteringType SkillRemoveBuffFilteringType { get; set; } // 0x1C

        [Key(4)]
        public int SkillRemoveBuffFilteringId { get; set; } // 0x20

        [Key(5)]
        public SkillRemoveBuffChoosingType SkillRemoveBuffChoosingType { get; set; } // 0x24
    }
}
