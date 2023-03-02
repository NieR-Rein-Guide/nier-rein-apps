using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillRemoveBuffFilterStatusKindTable : TableBase<EntityMSkillRemoveBuffFilterStatusKind>
    {
        private readonly Func<EntityMSkillRemoveBuffFilterStatusKind, (int,int)> primaryIndexSelector;

        public EntityMSkillRemoveBuffFilterStatusKindTable(EntityMSkillRemoveBuffFilterStatusKind[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.SkillRemoveBuffFilteringId,element.FilterIndex);
        }
        
        public RangeView<EntityMSkillRemoveBuffFilterStatusKind> FindRangeBySkillRemoveBuffFilteringIdAndFilterIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
