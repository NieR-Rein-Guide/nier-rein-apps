using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestDisplayEnemyThumbnailReplaceTable : TableBase<EntityMQuestDisplayEnemyThumbnailReplace>
    {
        private readonly Func<EntityMQuestDisplayEnemyThumbnailReplace, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMQuestDisplayEnemyThumbnailReplace, int> secondaryIndexSelector;

        public EntityMQuestDisplayEnemyThumbnailReplaceTable(EntityMQuestDisplayEnemyThumbnailReplace[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestId, element.Priority);
            secondaryIndexSelector = element => element.QuestId;
        }

        public RangeView<EntityMQuestDisplayEnemyThumbnailReplace> FindByQuestId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
