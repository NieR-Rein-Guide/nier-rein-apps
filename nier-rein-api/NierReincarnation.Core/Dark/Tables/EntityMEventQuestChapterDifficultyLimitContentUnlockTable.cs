using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestChapterDifficultyLimitContentUnlockTable : TableBase<EntityMEventQuestChapterDifficultyLimitContentUnlock>
    {
        private readonly Func<EntityMEventQuestChapterDifficultyLimitContentUnlock, (int,int)> primaryIndexSelector;
        private readonly Func<EntityMEventQuestChapterDifficultyLimitContentUnlock, int> secondaryIndexSelector;

        public EntityMEventQuestChapterDifficultyLimitContentUnlockTable(EntityMEventQuestChapterDifficultyLimitContentUnlock[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestChapterId,element.DifficultyType);
            secondaryIndexSelector = element => element.EventQuestChapterId;
        }
        
        public bool TryFindByEventQuestChapterIdAndDifficultyType(ValueTuple<int, int> key, out EntityMEventQuestChapterDifficultyLimitContentUnlock result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key, out result); }

    }
}
