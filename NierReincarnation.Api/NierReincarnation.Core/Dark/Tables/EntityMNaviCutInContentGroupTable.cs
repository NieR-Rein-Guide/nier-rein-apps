using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMNaviCutInContentGroupTable : TableBase<EntityMNaviCutInContentGroup>
{
    private readonly Func<EntityMNaviCutInContentGroup, (int, int)> primaryIndexSelector;

    public EntityMNaviCutInContentGroupTable(EntityMNaviCutInContentGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.NaviCutInContentGroupId, element.ContentIndex);
    }
}
