using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestTowerAssetTable : TableBase<EntityMEventQuestTowerAsset>
{
    private readonly Func<EntityMEventQuestTowerAsset, int> primaryIndexSelector;

    public EntityMEventQuestTowerAssetTable(EntityMEventQuestTowerAsset[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EventQuestChapterId;
    }

    public EntityMEventQuestTowerAsset FindByEventQuestChapterId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
