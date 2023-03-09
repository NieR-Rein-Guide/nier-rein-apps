using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusWeaponGroupTable : TableBase<EntityMQuestBonusWeaponGroup> // TypeDefIndex: 12361
    {
        // Fields
        private readonly Func<EntityMQuestBonusWeaponGroup, ValueTuple<int, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2E20634 Offset: 0x2E20634 VA: 0x2E20634
        public EntityMQuestBonusWeaponGroupTable(EntityMQuestBonusWeaponGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestBonusWeaponGroupId, group.WeaponId, group.LimitBreakCountLowerLimit);
        }

        // RVA: 0x2E20734 Offset: 0x2E20734 VA: 0x2E20734
        public RangeView<EntityMQuestBonusWeaponGroup> FindRangeByQuestBonusWeaponGroupIdAndWeaponIdAndLimitBreakCountLowerLimit(ValueTuple<int, int, int> min,
                ValueTuple<int, int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int, int)>.Default, min, max,
                ascendant);
        }
    }
}
