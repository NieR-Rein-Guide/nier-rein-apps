using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_base_status")]
    public class EntityMCompanionBaseStatus
    {
        [Key(0)] // RVA: 0x1DDB5CC Offset: 0x1DDB5CC VA: 0x1DDB5CC
        public int CompanionBaseStatusId { get; set; }

        [Key(1)] // RVA: 0x1DDB60C Offset: 0x1DDB60C VA: 0x1DDB60C
        public int Attack { get; set; }

        [Key(2)] // RVA: 0x1DDB620 Offset: 0x1DDB620 VA: 0x1DDB620
        public int Hp { get; set; }

        [Key(3)] // RVA: 0x1DDB634 Offset: 0x1DDB634 VA: 0x1DDB634
        public int Vitality { get; set; }
    }
}
