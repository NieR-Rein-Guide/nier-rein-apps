using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogCompanionTable : TableBase<EntityMCatalogCompanion>
    {
        private readonly Func<EntityMCatalogCompanion, int> primaryIndexSelector;

        public EntityMCatalogCompanionTable(EntityMCatalogCompanion[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CompanionId;
        }
    }
}
