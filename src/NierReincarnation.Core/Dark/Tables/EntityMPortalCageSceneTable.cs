using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPortalCageSceneTable : TableBase<EntityMPortalCageScene>
{
    private readonly Func<EntityMPortalCageScene, int> primaryIndexSelector;

    public EntityMPortalCageSceneTable(EntityMPortalCageScene[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PortalCageSceneId;
    }
}
