using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMImportantItemEffectTargetItemGroupTable : TableBase<EntityMImportantItemEffectTargetItemGroup>
{
    private readonly Func<EntityMImportantItemEffectTargetItemGroup, (int, int)> primaryIndexSelector;

    public EntityMImportantItemEffectTargetItemGroupTable(EntityMImportantItemEffectTargetItemGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.ImportantItemEffectTargetItemGroupId, element.TargetIndex);
    }
}
