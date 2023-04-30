using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogPartsGroupTable : TableBase<EntityMCatalogPartsGroup>
    {
        private readonly Func<EntityMCatalogPartsGroup, int> primaryIndexSelector;

        public EntityMCatalogPartsGroupTable(EntityMCatalogPartsGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.PartsGroupId;
        }
    }
}
