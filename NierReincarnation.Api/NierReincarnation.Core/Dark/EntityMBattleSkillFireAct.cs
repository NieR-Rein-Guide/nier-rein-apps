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
        public int BattleSkillFireActId { get; set; }

        [Key(1)]
        public int BattleSkillFireActConditionGroupId { get; set; }

        [Key(2)]
        public BattleSkillFireActConditionGroupType BattleSkillFireActConditionGroupType { get; set; }

        [Key(3)]
        public int BattleSkillFireActAssetId { get; set; }
    }
}
