using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_action_shorten_active_skill_cooltime")]
    public class EntityMSkillBehaviourActionShortenActiveSkillCooltime
    {
        [Key(0)]
        public int SkillBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public ActiveSkillType ActiveSkillType { get; set; } // 0x14

        [Key(2)]
        public int ShortenValuePermil { get; set; } // 0x18
    }
}
