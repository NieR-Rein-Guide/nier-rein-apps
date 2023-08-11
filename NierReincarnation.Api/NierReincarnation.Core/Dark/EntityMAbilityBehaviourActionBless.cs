using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour_action_bless")]
public class EntityMAbilityBehaviourActionBless
{
    [Key(0)]
    public int AbilityBehaviourActionId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int DecreasePoint { get; set; }
}
