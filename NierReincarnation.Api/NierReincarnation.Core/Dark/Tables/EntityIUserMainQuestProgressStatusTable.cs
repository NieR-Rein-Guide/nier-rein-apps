using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserMainQuestProgressStatusTable : TableBase<EntityIUserMainQuestProgressStatus>
    {
        private readonly Func<EntityIUserMainQuestProgressStatus, long> primaryIndexSelector;

        public EntityIUserMainQuestProgressStatusTable(EntityIUserMainQuestProgressStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserMainQuestProgressStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
    }
}
