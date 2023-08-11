using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_buff_resistance")]
public class EntityMSkillAbnormalBehaviourActionBuffResistance
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public BuffResistanceType BuffResistanceType { get; set; }

    [Key(2)]
    public BuffResistanceStatusKindType BuffResistanceStatusKindType { get; set; }

    [Key(3)]
    public int BlockProbabilityPermil { get; set; }
}
