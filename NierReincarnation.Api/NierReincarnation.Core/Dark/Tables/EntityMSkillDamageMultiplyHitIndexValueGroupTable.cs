using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillDamageMultiplyHitIndexValueGroupTable : TableBase<EntityMSkillDamageMultiplyHitIndexValueGroup>
    {
        private readonly Func<EntityMSkillDamageMultiplyHitIndexValueGroup, (int,int)> primaryIndexSelector;

        public EntityMSkillDamageMultiplyHitIndexValueGroupTable(EntityMSkillDamageMultiplyHitIndexValueGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.SkillDamageMultiplyHitIndexValueGroupId,element.SkillDamageMultiplyHitIndexValueGroupIndex);
        }
        
        public RangeView<EntityMSkillDamageMultiplyHitIndexValueGroup> FindRangeBySkillDamageMultiplyHitIndexValueGroupIdAndSkillDamageMultiplyHitIndexValueGroupIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
