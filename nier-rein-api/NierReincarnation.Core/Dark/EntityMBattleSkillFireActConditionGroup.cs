using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_skill_fire_act_condition_group")]
    public class EntityMBattleSkillFireActConditionGroup
    {
        [Key(0)]
        public int BattleSkillFireActConditionGroupId { get; set; } // 0x10
        [Key(1)]
        public int BattleSkillFireActConditionGroupOrder { get; set; } // 0x14
        [Key(2)]
        public BattleSkillFireActConditionType BattleSkillFireActConditionType { get; set; } // 0x18
        [Key(3)]
        public int BattleSkillFireActConditionId { get; set; } // 0x1C
    }
}