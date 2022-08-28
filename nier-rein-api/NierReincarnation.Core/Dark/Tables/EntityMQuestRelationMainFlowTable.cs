using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestRelationMainFlowTable : TableBase<EntityMQuestRelationMainFlow>
    {
        private readonly Func<EntityMQuestRelationMainFlow, (int,int)> primaryIndexSelector;

        public EntityMQuestRelationMainFlowTable(EntityMQuestRelationMainFlow[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MainFlowQuestId,element.DifficultyType);
        }
        
        public bool TryFindByMainFlowQuestIdAndDifficultyType(ValueTuple<int, int> key, out EntityMQuestRelationMainFlow result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key, out result); }

	
        public RangeView<EntityMQuestRelationMainFlow> FindRangeByMainFlowQuestIdAndDifficultyType(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
