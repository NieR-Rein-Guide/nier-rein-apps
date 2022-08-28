using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMLimitedOpenTextTable : TableBase<EntityMLimitedOpenText>
    {
        private readonly Func<EntityMLimitedOpenText, (int,int)> primaryIndexSelector;

        public EntityMLimitedOpenTextTable(EntityMLimitedOpenText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.LimitedOpenTargetType,element.TargetId);
        }
        
        public EntityMLimitedOpenText FindByLimitedOpenTargetTypeAndTargetId(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
