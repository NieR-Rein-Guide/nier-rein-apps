using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMFieldEffectBlessRelationTable : TableBase<EntityMFieldEffectBlessRelation>
    {
        private readonly Func<EntityMFieldEffectBlessRelation, (int, int)> primaryIndexSelector;

        public EntityMFieldEffectBlessRelationTable(EntityMFieldEffectBlessRelation[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.FieldEffectGroupId, element.FieldEffectBlessRelationIndex);
        }
    }
}
