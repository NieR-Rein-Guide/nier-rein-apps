using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMHeadupDisplayViewTable : TableBase<EntityMHeadupDisplayView>
    {
        private readonly Func<EntityMHeadupDisplayView, int> primaryIndexSelector;

        public EntityMHeadupDisplayViewTable(EntityMHeadupDisplayView[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.HeadupDisplayViewId;
        }

        public EntityMHeadupDisplayView FindByHeadupDisplayViewId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
