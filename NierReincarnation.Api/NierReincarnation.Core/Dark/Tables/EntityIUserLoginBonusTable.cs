using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserLoginBonusTable : TableBase<EntityIUserLoginBonus>
    {
        private readonly Func<EntityIUserLoginBonus, (long, int)> primaryIndexSelector;

        public EntityIUserLoginBonusTable(EntityIUserLoginBonus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.LoginBonusId);
        }

        public EntityIUserLoginBonus FindByUserIdAndLoginBonusId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }

        public bool TryFindByUserIdAndLoginBonusId(ValueTuple<long, int> key, out EntityIUserLoginBonus result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
