using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestDeckRestrictionGroupTable : TableBase<EntityMQuestDeckRestrictionGroup> // TypeDefIndex: 12137
    {
        // Fields
        private readonly Func<EntityMQuestDeckRestrictionGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C54108 Offset: 0x2C54108 VA: 0x2C54108
        public EntityMQuestDeckRestrictionGroupTable(EntityMQuestDeckRestrictionGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestDeckRestrictionGroupId, group.SlotNumber);
        }

        // RVA: 0x2C54208 Offset: 0x2C54208 VA: 0x2C54208
        public RangeView<EntityMQuestDeckRestrictionGroup> FindRangeByQuestDeckRestrictionGroupIdAndSlotNumber((int, int) min, (int, int) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
