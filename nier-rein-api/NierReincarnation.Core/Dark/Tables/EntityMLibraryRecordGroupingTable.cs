using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMLibraryRecordGroupingTable : TableBase<EntityMLibraryRecordGrouping>
    {
        private readonly Func<EntityMLibraryRecordGrouping, int> primaryIndexSelector;

        public EntityMLibraryRecordGroupingTable(EntityMLibraryRecordGrouping[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.LibraryRecordType;
        }
        
    }
}
