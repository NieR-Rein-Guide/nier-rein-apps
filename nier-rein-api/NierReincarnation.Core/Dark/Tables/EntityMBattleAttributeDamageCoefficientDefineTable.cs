using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleAttributeDamageCoefficientDefineTable : TableBase<EntityMBattleAttributeDamageCoefficientDefine>
    {
        private readonly Func<EntityMBattleAttributeDamageCoefficientDefine, int> primaryIndexSelector;

        public EntityMBattleAttributeDamageCoefficientDefineTable(EntityMBattleAttributeDamageCoefficientDefine[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSchemeType;
        }
        
        public EntityMBattleAttributeDamageCoefficientDefine FindByBattleSchemeType(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
