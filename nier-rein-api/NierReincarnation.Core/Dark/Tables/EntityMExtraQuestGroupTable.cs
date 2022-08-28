using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExtraQuestGroupTable : TableBase<EntityMExtraQuestGroup>
    {
        private readonly Func<EntityMExtraQuestGroup, (int,int)> primaryIndexSelector;

        public EntityMExtraQuestGroupTable(EntityMExtraQuestGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestId,element.ExtraQuestIndex);
        }
        
    }
}
