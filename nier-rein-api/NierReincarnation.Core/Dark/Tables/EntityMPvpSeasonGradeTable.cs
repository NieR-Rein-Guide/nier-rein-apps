using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpSeasonGradeTable : TableBase<EntityMPvpSeasonGrade>
    {
        private readonly Func<EntityMPvpSeasonGrade, (int,int)> primaryIndexSelector;

        public EntityMPvpSeasonGradeTable(EntityMPvpSeasonGrade[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PvpGradeId,element.PvpSeasonId);
        }
        
    }
}
