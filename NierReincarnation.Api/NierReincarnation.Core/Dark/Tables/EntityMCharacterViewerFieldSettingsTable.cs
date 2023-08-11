using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterViewerFieldSettingsTable : TableBase<EntityMCharacterViewerFieldSettings>
{
    private readonly Func<EntityMCharacterViewerFieldSettings, int> primaryIndexSelector;

    public EntityMCharacterViewerFieldSettingsTable(EntityMCharacterViewerFieldSettings[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AssetBackgroundId;
    }

    public EntityMCharacterViewerFieldSettings FindByAssetBackgroundId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByAssetBackgroundId(int key, out EntityMCharacterViewerFieldSettings result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
