using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActTable : TableBase<EntityMBattleSkillFireAct>
    {
        private readonly Func<EntityMBattleSkillFireAct, int> primaryIndexSelector;

        public EntityMBattleSkillFireActTable(EntityMBattleSkillFireAct[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSkillFireActId;
        }

        public bool TryFindByBattleSkillFireActId(int key, out EntityMBattleSkillFireAct result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
