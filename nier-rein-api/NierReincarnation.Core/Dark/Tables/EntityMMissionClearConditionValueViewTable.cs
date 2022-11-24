using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMMissionClearConditionValueViewTable : TableBase<EntityMMissionClearConditionValueView>
    {
        private readonly Func<EntityMMissionClearConditionValueView, int> primaryIndexSelector;

        public EntityMMissionClearConditionValueViewTable(EntityMMissionClearConditionValueView[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.MissionClearConditionType;
        }
        
        public bool TryFindByMissionClearConditionType(int key, out EntityMMissionClearConditionValueView result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
