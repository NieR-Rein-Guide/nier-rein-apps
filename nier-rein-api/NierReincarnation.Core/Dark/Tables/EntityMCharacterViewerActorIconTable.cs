using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterViewerActorIconTable : TableBase<EntityMCharacterViewerActorIcon>
    {
        private readonly Func<EntityMCharacterViewerActorIcon, (int,int,int)> primaryIndexSelector;

        public EntityMCharacterViewerActorIconTable(EntityMCharacterViewerActorIcon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAssetCategoryType,element.SkeletonId,element.AssetVariationId);
        }
        
        public bool TryFindByCostumeAssetCategoryTypeAndSkeletonIdAndAssetVariationId(ValueTuple<int, int, int> key, out EntityMCharacterViewerActorIcon result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, key, out result); }

    }
}
