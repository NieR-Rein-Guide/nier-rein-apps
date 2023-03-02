using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMUserQuestSceneGrantPossessionTable : TableBase<EntityMUserQuestSceneGrantPossession>
    {
        private readonly Func<EntityMUserQuestSceneGrantPossession, (int, PossessionType, int)> primaryIndexSelector;

        public EntityMUserQuestSceneGrantPossessionTable(EntityMUserQuestSceneGrantPossession[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestSceneId,element.PossessionType,element.PossessionId);
        }
        
        public RangeView<EntityMUserQuestSceneGrantPossession> FindRangeByQuestSceneIdAndPossessionTypeAndPossessionId(ValueTuple<int, PossessionType, int> min, ValueTuple<int, PossessionType, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, PossessionType, int)>.Default, min, max, ascendant); }

    }
}
