using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMStainedGlassStatusUpTargetGroupTable : TableBase<EntityMStainedGlassStatusUpTargetGroup>
    {
        private readonly Func<EntityMStainedGlassStatusUpTargetGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMStainedGlassStatusUpTargetGroup, int> secondaryIndexSelector;

        public EntityMStainedGlassStatusUpTargetGroupTable(EntityMStainedGlassStatusUpTargetGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.StainedGlassStatusUpTargetGroupId, element.GroupIndex);
            secondaryIndexSelector = element => element.StainedGlassStatusUpTargetGroupId;
        }

        public RangeView<EntityMStainedGlassStatusUpTargetGroup> FindByStainedGlassStatusUpTargetGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
