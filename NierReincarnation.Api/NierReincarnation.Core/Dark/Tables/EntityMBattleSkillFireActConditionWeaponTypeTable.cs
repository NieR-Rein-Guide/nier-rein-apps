using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActConditionWeaponTypeTable : TableBase<EntityMBattleSkillFireActConditionWeaponType>
    {
        private readonly Func<EntityMBattleSkillFireActConditionWeaponType, int> primaryIndexSelector;

        public EntityMBattleSkillFireActConditionWeaponTypeTable(EntityMBattleSkillFireActConditionWeaponType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BattleSkillFireActConditionId;
        }

        public bool TryFindByBattleSkillFireActConditionId(int key, out EntityMBattleSkillFireActConditionWeaponType result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
