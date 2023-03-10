using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserSideStoryQuestSceneProgressStatusTable : TableBase<EntityIUserSideStoryQuestSceneProgressStatus>
    {
        private readonly Func<EntityIUserSideStoryQuestSceneProgressStatus, long> primaryIndexSelector;

        public EntityIUserSideStoryQuestSceneProgressStatusTable(EntityIUserSideStoryQuestSceneProgressStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserSideStoryQuestSceneProgressStatus FindByUserId(long key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key); }
    }
}
