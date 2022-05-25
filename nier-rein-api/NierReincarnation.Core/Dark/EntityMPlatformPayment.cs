using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_platform_payment")]
    public class EntityMPlatformPayment
    {
        [Key(0)] // RVA: 0x1DDD294 Offset: 0x1DDD294 VA: 0x1DDD294
        public int PlatformPaymentId { get; set; }
        [Key(1)] // RVA: 0x1DDD2D4 Offset: 0x1DDD2D4 VA: 0x1DDD2D4
        public PlatformType PlatformType { get; set; }
        [Key(2)] // RVA: 0x1DDD314 Offset: 0x1DDD314 VA: 0x1DDD314
        public string ProductIdSuffix { get; set; }
	}
}
