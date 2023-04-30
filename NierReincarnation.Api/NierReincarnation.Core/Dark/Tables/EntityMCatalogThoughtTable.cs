using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogThoughtTable : TableBase<EntityMCatalogThought>
    {
        private readonly Func<EntityMCatalogThought, int> primaryIndexSelector;

        public EntityMCatalogThoughtTable(EntityMCatalogThought[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ThoughtId;
        }
    }
}
