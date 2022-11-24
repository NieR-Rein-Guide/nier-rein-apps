using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActTable : TableBase<EntityMBattleSkillFireAct>
    {
        private readonly Func<EntityMBattleSkillFireAct, int> primaryIndexSelector;

        public EntityMBattleSkillFireActTable(EntityMBattleSkillFireAct[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSkillFireActId;
        }
        
        public bool TryFindByBattleSkillFireActId(int key, out EntityMBattleSkillFireAct result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
