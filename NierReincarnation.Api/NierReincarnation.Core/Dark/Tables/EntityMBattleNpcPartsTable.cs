using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcPartsTable : TableBase<EntityMBattleNpcParts>
    {
        private readonly Func<EntityMBattleNpcParts, (long,string)> primaryIndexSelector;

        public EntityMBattleNpcPartsTable(EntityMBattleNpcParts[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId,element.BattleNpcPartsUuid);
        }
        
        public EntityMBattleNpcParts FindByBattleNpcIdAndBattleNpcPartsUuid(ValueTuple<long, string> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long,string)>.Default, key); }

    }
}
