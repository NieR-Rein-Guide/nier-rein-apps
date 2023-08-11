using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_platform_payment_price")]
public class EntityMPlatformPaymentPrice
{
    [Key(0)]
    public int PlatformPaymentId { get; set; }

    [Key(1)]
    public PlatformType PlatformType { get; set; }

    [Key(2)]
    public int CurrencyType { get; set; }

    [Key(3)]
    public decimal Price { get; set; }
}
