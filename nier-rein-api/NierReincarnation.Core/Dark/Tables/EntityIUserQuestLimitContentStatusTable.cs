using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserQuestLimitContentStatusTable : TableBase<EntityIUserQuestLimitContentStatus> // TypeDefIndex: 13022
    {
        // Fields
        private readonly Func<EntityIUserQuestLimitContentStatus, ValueTuple<long, int>> primaryIndexSelector; // 0x18
        private readonly Func<EntityIUserQuestLimitContentStatus, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x37FA178 Offset: 0x37FA178 VA: 0x37FA178
        public EntityIUserQuestLimitContentStatusTable(EntityIUserQuestLimitContentStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => (status.UserId, status.QuestId);
            secondaryIndex0Selector = status => status.EventQuestChapterId;
        }

        // RVA: 0x37FA330 Offset: 0x37FA330 VA: 0x37FA330
        public EntityIUserQuestLimitContentStatus FindByUserIdAndQuestId(ValueTuple<long, int> key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
        }
    }
}
