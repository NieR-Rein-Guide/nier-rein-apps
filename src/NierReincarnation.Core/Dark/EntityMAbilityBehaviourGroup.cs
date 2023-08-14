using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour_group")]
public class EntityMAbilityBehaviourGroup
{
    [Key(0)]
    public int AbilityBehaviourGroupId { get; set; }

    [Key(1)]
    public int AbilityBehaviourIndex { get; set; }

    [Key(2)]
    public int AbilityBehaviourId { get; set; }
}
