using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPortalCageCharacterGroupTable : TableBase<EntityMPortalCageCharacterGroup>
    {
        private readonly Func<EntityMPortalCageCharacterGroup, int> primaryIndexSelector;

        public EntityMPortalCageCharacterGroupTable(EntityMPortalCageCharacterGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.PortalCageCharacterGroupId;
        }
        
        public bool TryFindByPortalCageCharacterGroupId(int key, out EntityMPortalCageCharacterGroup result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
