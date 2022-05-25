using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_power_reference_status_group")]
    public class EntityMPowerReferenceStatusGroup
    {
        [Key(0)] // RVA: 0x1DE0DB0 Offset: 0x1DE0DB0 VA: 0x1DE0DB0
        public int PowerReferenceStatusGroupId { get; set; }
        [Key(1)] // RVA: 0x1DE0DF0 Offset: 0x1DE0DF0 VA: 0x1DE0DF0
        public StatusKindType ReferenceStatusType { get; set; }
        [Key(2)] // RVA: 0x1DE0E30 Offset: 0x1DE0E30 VA: 0x1DE0E30
        public AttributeConditionType AttributeConditionType { get; set; }
        [Key(3)] // RVA: 0x1DE0E44 Offset: 0x1DE0E44 VA: 0x1DE0E44
        public int CoefficientValuePermil { get; set; }
	}
}
