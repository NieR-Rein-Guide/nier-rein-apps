using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMDeckEntrustCoefficientAttributeTable : TableBase<EntityMDeckEntrustCoefficientAttribute>
{
    private readonly Func<EntityMDeckEntrustCoefficientAttribute, (AttributeType, AttributeType)> primaryIndexSelector;

    public EntityMDeckEntrustCoefficientAttributeTable(EntityMDeckEntrustCoefficientAttribute[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EntrustAttributeType, element.AttributeType);
    }
}
