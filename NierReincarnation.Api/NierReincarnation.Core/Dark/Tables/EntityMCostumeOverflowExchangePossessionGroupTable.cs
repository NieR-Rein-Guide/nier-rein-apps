using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeOverflowExchangePossessionGroupTable : TableBase<EntityMCostumeOverflowExchangePossessionGroup>
    {
        private readonly Func<EntityMCostumeOverflowExchangePossessionGroup, (int, int)> primaryIndexSelector;

        public EntityMCostumeOverflowExchangePossessionGroupTable(EntityMCostumeOverflowExchangePossessionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MaterialId, element.SortOrder);
        }
    }
}
