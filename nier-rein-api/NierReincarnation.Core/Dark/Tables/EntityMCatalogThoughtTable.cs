using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogThoughtTable : TableBase<EntityMCatalogThought> // TypeDefIndex: 11931
    {
        // Fields
        private readonly Func<EntityMCatalogThought, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D35500 Offset: 0x2D35500 VA: 0x2D35500
        public EntityMCatalogThoughtTable(EntityMCatalogThought[] sortedData):base(sortedData)
        {
            primaryIndexSelector = thought => thought.ThoughtId;
        }
    }
}
