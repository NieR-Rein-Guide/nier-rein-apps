using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeCollectionBonusGroupTable : TableBase<EntityMCostumeCollectionBonusGroup>
    {
        private readonly Func<EntityMCostumeCollectionBonusGroup, (int, int)> primaryIndexSelector;

        public EntityMCostumeCollectionBonusGroupTable(EntityMCostumeCollectionBonusGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CollectionBonusGroupId, element.CostumeId);
        }
    }
}
