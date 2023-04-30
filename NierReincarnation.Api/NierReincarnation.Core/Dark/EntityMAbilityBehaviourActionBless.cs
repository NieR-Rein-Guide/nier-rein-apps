using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_behaviour_action_bless")]
    public class EntityMAbilityBehaviourActionBless
    {
        [Key(0)]
        public int AbilityBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int AbilityId { get; set; } // 0x14

        [Key(2)]
        public int DecreasePoint { get; set; } // 0x18
    }
}
