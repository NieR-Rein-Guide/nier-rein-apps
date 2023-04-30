using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActConditionSkillCategoryTypeTable : TableBase<EntityMBattleSkillFireActConditionSkillCategoryType>
    {
        private readonly Func<EntityMBattleSkillFireActConditionSkillCategoryType, int> primaryIndexSelector;

        public EntityMBattleSkillFireActConditionSkillCategoryTypeTable(EntityMBattleSkillFireActConditionSkillCategoryType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSkillFireActConditionId;
        }

        public bool TryFindByBattleSkillFireActConditionId(int key, out EntityMBattleSkillFireActConditionSkillCategoryType result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
