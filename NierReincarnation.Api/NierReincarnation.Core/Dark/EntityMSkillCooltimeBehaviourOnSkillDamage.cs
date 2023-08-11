using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_cooltime_behaviour_on_skill_damage")]
    public class EntityMSkillCooltimeBehaviourOnSkillDamage
    {
        [Key(0)]
        public int SkillCooltimeBehaviourActionId { get; set; }

        [Key(1)]
        public int SkillCooltimeAdvanceValueCalculationId { get; set; }
    }
}
