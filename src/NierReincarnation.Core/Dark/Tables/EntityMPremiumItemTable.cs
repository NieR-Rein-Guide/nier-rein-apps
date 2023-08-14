using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPremiumItemTable : TableBase<EntityMPremiumItem>
{
    private readonly Func<EntityMPremiumItem, int> primaryIndexSelector;

    public EntityMPremiumItemTable(EntityMPremiumItem[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PremiumItemId;
    }
}
