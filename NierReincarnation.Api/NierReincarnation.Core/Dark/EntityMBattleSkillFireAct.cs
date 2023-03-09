using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_skill_fire_act")]
    public class EntityMBattleSkillFireAct
    {
        [Key(0)]
        public int BattleSkillFireActId { get; set; } // 0x10
        [Key(1)]
        public int BattleSkillFireActConditionGroupId { get; set; } // 0x14
        [Key(2)]
        public BattleSkillFireActConditionGroupType BattleSkillFireActConditionGroupType { get; set; } // 0x18
        [Key(3)]
        public int BattleSkillFireActAssetId { get; set; } // 0x1C
    }
}