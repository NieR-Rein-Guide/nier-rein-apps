using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour")]
public class EntityMAbilityBehaviour
{
    [Key(0)]
    public int AbilityBehaviourId { get; set; }

    [Key(1)]
    public AbilityBehaviourType AbilityBehaviourType { get; set; }

    [Key(2)]
    public int AbilityBehaviourActionId { get; set; }
}
