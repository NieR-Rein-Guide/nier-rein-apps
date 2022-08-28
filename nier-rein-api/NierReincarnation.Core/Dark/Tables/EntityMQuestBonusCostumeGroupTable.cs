using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusCostumeGroupTable : TableBase<EntityMQuestBonusCostumeGroup>
    {
        private readonly Func<EntityMQuestBonusCostumeGroup, (int,int)> primaryIndexSelector;

        public EntityMQuestBonusCostumeGroupTable(EntityMQuestBonusCostumeGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestBonusCostumeGroupId,element.CostumeId);
        }
        
    }
}
