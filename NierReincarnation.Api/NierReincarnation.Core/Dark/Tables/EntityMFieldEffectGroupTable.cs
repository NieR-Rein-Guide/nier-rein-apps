using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMFieldEffectGroupTable : TableBase<EntityMFieldEffectGroup>
    {
        private readonly Func<EntityMFieldEffectGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMFieldEffectGroup, int> secondaryIndexSelector;

        public EntityMFieldEffectGroupTable(EntityMFieldEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.FieldEffectGroupId, element.FieldEffectGroupIndex);
            secondaryIndexSelector = element => element.FieldEffectGroupId;
        }

        public RangeView<EntityMFieldEffectGroup> FindByFieldEffectGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
