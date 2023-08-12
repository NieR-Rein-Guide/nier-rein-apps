using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPlatformPaymentTable : TableBase<EntityMPlatformPayment>
{
    private readonly Func<EntityMPlatformPayment, (int, PlatformType)> primaryIndexSelector;

    public EntityMPlatformPaymentTable(EntityMPlatformPayment[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PlatformPaymentId, element.PlatformType);
    }

    public EntityMPlatformPayment FindByPlatformPaymentIdAndPlatformType(ValueTuple<int, PlatformType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, PlatformType)>.Default, key);
}
