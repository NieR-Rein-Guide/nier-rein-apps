using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_cooltime_behaviour")]
public class EntityMSkillCooltimeBehaviour
{
    [Key(0)]
    public int SkillCooltimeBehaviourId { get; set; }

    [Key(1)]
    public SkillCooltimeBehaviourType SkillCooltimeBehaviourType { get; set; }

    [Key(2)]
    public int SkillCooltimeBehaviourActionId { get; set; }
}
