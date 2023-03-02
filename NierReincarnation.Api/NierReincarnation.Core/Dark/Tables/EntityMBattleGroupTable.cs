using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleGroupTable : TableBase<EntityMBattleGroup> // TypeDefIndex: 11621
    {
        // Fields
        private readonly Func<EntityMBattleGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C45488 Offset: 0x2C45488 VA: 0x2C45488
        public EntityMBattleGroupTable(EntityMBattleGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.BattleGroupId, group.WaveNumber);
        }

        // RVA: 0x2C45588 Offset: 0x2C45588 VA: 0x2C45588
        public RangeView<EntityMBattleGroup> FindRangeByBattleGroupIdAndWaveNumber(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
