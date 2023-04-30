using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserAppleTable : TableBase<EntityIUserApple>
    {
        private readonly Func<EntityIUserApple, long> primaryIndexSelector;

        public EntityIUserAppleTable(EntityIUserApple[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserApple FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
    }
}
