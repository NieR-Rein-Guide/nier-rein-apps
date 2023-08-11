using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_skill_fire_act_condition_attribute_type")]
    public class EntityMBattleSkillFireActConditionAttributeType
    {
        [Key(0)]
        public int BattleSkillFireActConditionId { get; set; }

        [Key(1)]
        public int AttributeType { get; set; }
    }
}
