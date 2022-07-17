using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusTermGroupTable : TableBase<EntityMQuestBonusTermGroup> // TypeDefIndex: 12359
    {
        // Fields
        private readonly Func<EntityMQuestBonusTermGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18
        private readonly Func<EntityMQuestBonusTermGroup, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x2D10424 Offset: 0x2D10424 VA: 0x2D10424
        public EntityMQuestBonusTermGroupTable(EntityMQuestBonusTermGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestBonusTermGroupId, group.SortOrder);
            secondaryIndex0Selector = group => group.QuestBonusTermGroupId;
        }

        // RVA: 0x2D105DC Offset: 0x2D105DC VA: 0x2D105DC
        public RangeView<EntityMQuestBonusTermGroup> FindByQuestBonusTermGroupId(int key)
        {
            var result = new List<EntityMQuestBonusTermGroup>();

            foreach (var element in data)
                if (secondaryIndex0Selector(element) == key)
                    result.Add(element);

            return new RangeView<EntityMQuestBonusTermGroup>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}
