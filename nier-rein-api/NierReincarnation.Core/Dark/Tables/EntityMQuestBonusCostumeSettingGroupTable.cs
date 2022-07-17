using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusCostumeSettingGroupTable : TableBase<EntityMQuestBonusCostumeSettingGroup> // TypeDefIndex: 12349
    {
        // Fields
        private readonly Func<EntityMQuestBonusCostumeSettingGroup, ValueTuple<int, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D0F8B4 Offset: 0x2D0F8B4 VA: 0x2D0F8B4
        public EntityMQuestBonusCostumeSettingGroupTable(EntityMQuestBonusCostumeSettingGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestBonusCostumeSettingGroupId, group.CostumeId, group.LimitBreakCountLowerLimit);
        }

        // RVA: 0x2D0F9B4 Offset: 0x2D0F9B4 VA: 0x2D0F9B4
        public RangeView<EntityMQuestBonusCostumeSettingGroup> FindRangeByQuestBonusCostumeSettingGroupIdAndCostumeIdAndLimitBreakCountLowerLimit(
                ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int, int)>.Default, min, max,
                ascendant);
        }
    }
}
