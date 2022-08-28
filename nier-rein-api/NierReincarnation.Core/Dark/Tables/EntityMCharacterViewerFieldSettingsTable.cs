using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterViewerFieldSettingsTable : TableBase<EntityMCharacterViewerFieldSettings>
    {
        private readonly Func<EntityMCharacterViewerFieldSettings, int> primaryIndexSelector;

        public EntityMCharacterViewerFieldSettingsTable(EntityMCharacterViewerFieldSettings[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AssetBackgroundId;
        }
        
        public EntityMCharacterViewerFieldSettings FindByAssetBackgroundId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public bool TryFindByAssetBackgroundId(int key, out EntityMCharacterViewerFieldSettings result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
