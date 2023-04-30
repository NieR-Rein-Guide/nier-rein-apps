using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable : TableBase<EntityMSkillDamageMultiplyAbnormalAttachedValueGroup>
    {
        private readonly Func<EntityMSkillDamageMultiplyAbnormalAttachedValueGroup, (int, int)> primaryIndexSelector;

        public EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable(EntityMSkillDamageMultiplyAbnormalAttachedValueGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.SkillDamageMultiplyAbnormalAttachedValueGroupId, element.SkillDamageMultiplyAbnormalAttachedValueGroupIndex);
        }

        public RangeView<EntityMSkillDamageMultiplyAbnormalAttachedValueGroup> FindRangeBySkillDamageMultiplyAbnormalAttachedValueGroupIdAndSkillDamageMultiplyAbnormalAttachedValueGroupIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
