using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_lifetime")]
public class EntityMSkillAbnormalLifetime
{
    [Key(0)]
    public int SkillAbnormalLifetimeId { get; set; }

    [Key(1)]
    public int SkillAbnormalLifetimeBehaviourGroupId { get; set; }

    [Key(2)]
    public AbnormalLifetimeBehaviourConditionType AbnormalLifetimeBehaviourConditionType { get; set; }
}
