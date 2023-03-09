using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestPickupRewardGroupTable : TableBase<EntityMQuestPickupRewardGroup>
    {
        private readonly Func<EntityMQuestPickupRewardGroup, (int,int)> primaryIndexSelector;

        public EntityMQuestPickupRewardGroupTable(EntityMQuestPickupRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestPickupRewardGroupId,element.SortOrder);
        }
        
    }
}
