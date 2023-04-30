using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMDeckEntrustCoefficientAttributeTable : TableBase<EntityMDeckEntrustCoefficientAttribute>
    {
        private readonly Func<EntityMDeckEntrustCoefficientAttribute, (int, int)> primaryIndexSelector;

        public EntityMDeckEntrustCoefficientAttributeTable(EntityMDeckEntrustCoefficientAttribute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EntrustAttributeType, element.AttributeType);
        }
    }
}
