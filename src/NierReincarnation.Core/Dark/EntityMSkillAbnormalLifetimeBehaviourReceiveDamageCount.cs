using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_lifetime_behaviour_receive_damage_count")]
public class EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCount
{
    [Key(0)]
    public int SkillAbnormalLifetimeBehaviourId { get; set; }

    [Key(1)]
    public int ReceiveDamageCount { get; set; }
}
