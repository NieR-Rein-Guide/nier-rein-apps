using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpGradeTable : TableBase<EntityMPvpGrade>
    {
        private readonly Func<EntityMPvpGrade, int> primaryIndexSelector;

        public EntityMPvpGradeTable(EntityMPvpGrade[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.PvpGradeId;
        }
        
    }
}
