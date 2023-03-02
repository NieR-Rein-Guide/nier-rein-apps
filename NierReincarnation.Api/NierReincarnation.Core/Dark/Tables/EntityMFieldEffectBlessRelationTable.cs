using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMFieldEffectBlessRelationTable : TableBase<EntityMFieldEffectBlessRelation>
    {
        private readonly Func<EntityMFieldEffectBlessRelation, (int,int)> primaryIndexSelector;

        public EntityMFieldEffectBlessRelationTable(EntityMFieldEffectBlessRelation[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.FieldEffectGroupId,element.FieldEffectBlessRelationIndex);
        }
        
        public RangeView<EntityMFieldEffectBlessRelation> FindRangeByFieldEffectGroupIdAndFieldEffectBlessRelationIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
