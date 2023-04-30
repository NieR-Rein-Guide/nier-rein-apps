using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipGroupSelectionTable : TableBase<EntityMTipGroupSelection>
    {
        private readonly Func<EntityMTipGroupSelection, (int, int)> primaryIndexSelector;

        public EntityMTipGroupSelectionTable(EntityMTipGroupSelection[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.TipGroupId, element.TipId);
        }
    }
}
