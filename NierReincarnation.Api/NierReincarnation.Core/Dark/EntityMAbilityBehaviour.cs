using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_behaviour")]
    public class EntityMAbilityBehaviour
    {
        [Key(0)] // RVA: 0x1DD630C Offset: 0x1DD630C VA: 0x1DD630C
        public int AbilityBehaviourId { get; set; }

        [Key(1)] // RVA: 0x1DD634C Offset: 0x1DD634C VA: 0x1DD634C
        public AbilityBehaviourType AbilityBehaviourType { get; set; }

        [Key(2)] // RVA: 0x1DD6360 Offset: 0x1DD6360 VA: 0x1DD6360
        public int AbilityBehaviourActionId { get; set; }
    }
}
