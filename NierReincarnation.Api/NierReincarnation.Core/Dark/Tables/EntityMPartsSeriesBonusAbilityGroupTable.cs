using System;
using System.Collections;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsSeriesBonusAbilityGroupTable : TableBase<EntityMPartsSeriesBonusAbilityGroup> // TypeDefIndex: 12057
    {
        // Fields
        private readonly Func<EntityMPartsSeriesBonusAbilityGroup, ValueTuple<int, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C52460 Offset: 0x2C52460 VA: 0x2C52460
        public EntityMPartsSeriesBonusAbilityGroupTable(EntityMPartsSeriesBonusAbilityGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.PartsSeriesBonusAbilityGroupId, group.SetCount, group.AbilityId);
        }

        public RangeView<EntityMPartsSeriesBonusAbilityGroup> FindRangeByPartsSeriesBonusAbilityGroupIdAndSetCountAndAbilityId(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int, int)>.Default, min, max, ascendant);
        }
    }
}
