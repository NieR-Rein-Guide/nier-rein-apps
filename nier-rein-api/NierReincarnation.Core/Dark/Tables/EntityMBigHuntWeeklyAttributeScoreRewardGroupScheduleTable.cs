using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable : TableBase<EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule>
    {
        private readonly Func<EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule, (int,int,int)> primaryIndexSelector;

        public EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable(EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BigHuntWeeklyAttributeScoreRewardGroupScheduleId,element.AttributeType,element.GroupIndex);
        }
        
    }
}
