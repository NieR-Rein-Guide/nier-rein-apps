using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_behaviour_action_passive_skill")]
    public class EntityMAbilityBehaviourActionPassiveSkill
    {
        [Key(0)] // RVA: 0x1DD6374 Offset: 0x1DD6374 VA: 0x1DD6374
        public int AbilityBehaviourActionId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD63B4 Offset: 0x1DD63B4 VA: 0x1DD63B4
        public int SkillDetailId { get; set; } // 0x14
    }
}
