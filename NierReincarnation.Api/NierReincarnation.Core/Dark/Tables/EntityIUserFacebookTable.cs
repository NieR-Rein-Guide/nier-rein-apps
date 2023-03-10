using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserFacebookTable : TableBase<EntityIUserFacebook>
    {
        private readonly Func<EntityIUserFacebook, long> primaryIndexSelector;

        public EntityIUserFacebookTable(EntityIUserFacebook[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserFacebook FindByUserId(long key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key); }
    }
}
