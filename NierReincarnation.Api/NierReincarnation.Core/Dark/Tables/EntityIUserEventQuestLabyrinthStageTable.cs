using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserEventQuestLabyrinthStageTable : TableBase<EntityIUserEventQuestLabyrinthStage>
    {
        private readonly Func<EntityIUserEventQuestLabyrinthStage, (long, int, int)> primaryIndexSelector;

        public EntityIUserEventQuestLabyrinthStageTable(EntityIUserEventQuestLabyrinthStage[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.EventQuestChapterId, element.StageOrder);
        }

        public EntityIUserEventQuestLabyrinthStage FindByUserIdAndEventQuestChapterIdAndStageOrder(ValueTuple<long, int, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key); }

        public bool TryFindByUserIdAndEventQuestChapterIdAndStageOrder(ValueTuple<long, int, int> key, out EntityIUserEventQuestLabyrinthStage result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key, out result); }
    }
}
