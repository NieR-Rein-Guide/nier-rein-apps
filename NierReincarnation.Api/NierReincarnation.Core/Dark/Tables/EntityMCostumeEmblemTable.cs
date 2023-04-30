using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeEmblemTable : TableBase<EntityMCostumeEmblem>
    {
        private readonly Func<EntityMCostumeEmblem, int> primaryIndexSelector;

        public EntityMCostumeEmblemTable(EntityMCostumeEmblem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CostumeEmblemAssetId;
        }

        public EntityMCostumeEmblem FindByCostumeEmblemAssetId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
