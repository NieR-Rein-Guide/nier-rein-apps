using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActConditionSkillCategoryTypeTable : TableBase<EntityMBattleSkillFireActConditionSkillCategoryType>
    {
        private readonly Func<EntityMBattleSkillFireActConditionSkillCategoryType, int> primaryIndexSelector;

        public EntityMBattleSkillFireActConditionSkillCategoryTypeTable(EntityMBattleSkillFireActConditionSkillCategoryType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSkillFireActConditionId;
        }
        
        public bool TryFindByBattleSkillFireActConditionId(int key, out EntityMBattleSkillFireActConditionSkillCategoryType result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
