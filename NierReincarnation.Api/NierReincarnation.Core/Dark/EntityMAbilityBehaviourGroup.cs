using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_behaviour_group")]
    public class EntityMAbilityBehaviourGroup
    {
        [Key(0)] // RVA: 0x1DD646C Offset: 0x1DD646C VA: 0x1DD646C
        public int AbilityBehaviourGroupId { get; set; }

        [Key(1)] // RVA: 0x1DD64AC Offset: 0x1DD64AC VA: 0x1DD64AC
        public int AbilityBehaviourIndex { get; set; }

        [Key(2)] // RVA: 0x1DD64EC Offset: 0x1DD64EC VA: 0x1DD64EC
        public int AbilityBehaviourId { get; set; }
    }
}
