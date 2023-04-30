using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserEventQuestProgressStatusTable : TableBase<EntityIUserEventQuestProgressStatus>
    {
        private readonly Func<EntityIUserEventQuestProgressStatus, long> primaryIndexSelector;

        public EntityIUserEventQuestProgressStatusTable(EntityIUserEventQuestProgressStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserEventQuestProgressStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
    }
}
