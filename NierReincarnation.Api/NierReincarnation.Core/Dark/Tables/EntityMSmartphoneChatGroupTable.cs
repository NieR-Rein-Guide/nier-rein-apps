using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSmartphoneChatGroupTable : TableBase<EntityMSmartphoneChatGroup>
    {
        private readonly Func<EntityMSmartphoneChatGroup, int> primaryIndexSelector;

        public EntityMSmartphoneChatGroupTable(EntityMSmartphoneChatGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SmartphoneChatGroupId;
        }
        
        public RangeView<EntityMSmartphoneChatGroup> FindRangeBySmartphoneChatGroupId(int min, int max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<int>.Default, min, max, ascendant); }

    }
}
