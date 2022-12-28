using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestRelationMainFlowTable : TableBase<EntityMQuestRelationMainFlow>
    {
        private readonly Func<EntityMQuestRelationMainFlow, (int, DifficultyType)> primaryIndexSelector;

        public EntityMQuestRelationMainFlowTable(EntityMQuestRelationMainFlow[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.MainFlowQuestId,element.DifficultyType);
        }
        
        public bool TryFindByMainFlowQuestIdAndDifficultyType(ValueTuple<int, DifficultyType> key, out EntityMQuestRelationMainFlow result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, key, out result); }

	
        public RangeView<EntityMQuestRelationMainFlow> FindRangeByMainFlowQuestIdAndDifficultyType(ValueTuple<int, DifficultyType> min, ValueTuple<int, DifficultyType> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, DifficultyType)>.Default, min, max, ascendant); }

    }
}
