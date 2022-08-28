using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMUserQuestSceneGrantPossessionTable : TableBase<EntityMUserQuestSceneGrantPossession>
    {
        private readonly Func<EntityMUserQuestSceneGrantPossession, (int,int,int)> primaryIndexSelector;

        public EntityMUserQuestSceneGrantPossessionTable(EntityMUserQuestSceneGrantPossession[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneId,element.PossessionType,element.PossessionId);
        }
        
        public RangeView<EntityMUserQuestSceneGrantPossession> FindRangeByQuestSceneIdAndPossessionTypeAndPossessionId(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, min, max, ascendant); }

    }
}
