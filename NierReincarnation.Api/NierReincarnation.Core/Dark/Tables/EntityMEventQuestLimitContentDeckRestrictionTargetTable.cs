using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLimitContentDeckRestrictionTargetTable : TableBase<EntityMEventQuestLimitContentDeckRestrictionTarget>
    {
        private readonly Func<EntityMEventQuestLimitContentDeckRestrictionTarget, (int, LimitContentDeckRestrictionType)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestLimitContentDeckRestrictionTarget, int> secondaryIndexSelector;

        public EntityMEventQuestLimitContentDeckRestrictionTargetTable(EntityMEventQuestLimitContentDeckRestrictionTarget[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestLimitContentDeckRestrictionTargetId, element.LimitContentDeckRestrictionType);
            secondaryIndexSelector = element => element.EventQuestLimitContentDeckRestrictionTargetId;
        }

        public RangeView<EntityMEventQuestLimitContentDeckRestrictionTarget> FindByEventQuestLimitContentDeckRestrictionTargetId(int key) =>
            FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
