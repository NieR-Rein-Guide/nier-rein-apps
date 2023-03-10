using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserTutorialProgressTable : TableBase<EntityIUserTutorialProgress>
    {
        private readonly Func<EntityIUserTutorialProgress, (long, int)> primaryIndexSelector;

        public EntityIUserTutorialProgressTable(EntityIUserTutorialProgress[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.TutorialType);
        }

        public bool TryFindByUserIdAndTutorialType(ValueTuple<long, int> key, out EntityIUserTutorialProgress result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
