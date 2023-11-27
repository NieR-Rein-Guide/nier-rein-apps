using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPlatformPayment))]
public class EntityMPlatformPayment
{
    [Key(0)]
    public int PlatformPaymentId { get; set; }

    [Key(1)]
    public PlatformType PlatformType { get; set; }

    [Key(2)]
    public string ProductIdSuffix { get; set; }
}
