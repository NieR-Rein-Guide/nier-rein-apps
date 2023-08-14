using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMImportantItemEffectDropCountTable : TableBase<EntityMImportantItemEffectDropCount>
{
    private readonly Func<EntityMImportantItemEffectDropCount, int> primaryIndexSelector;

    public EntityMImportantItemEffectDropCountTable(EntityMImportantItemEffectDropCount[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ImportantItemEffectDropCountId;
    }
}
