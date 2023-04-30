using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleSkillFireActConditionGroupTable : TableBase<EntityMBattleSkillFireActConditionGroup>
    {
        private readonly Func<EntityMBattleSkillFireActConditionGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMBattleSkillFireActConditionGroup, int> secondaryIndexSelector;

        public EntityMBattleSkillFireActConditionGroupTable(EntityMBattleSkillFireActConditionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleSkillFireActConditionGroupId, element.BattleSkillFireActConditionGroupOrder);
            secondaryIndexSelector = element => element.BattleSkillFireActConditionGroupId;
        }

        public RangeView<EntityMBattleSkillFireActConditionGroup> FindByBattleSkillFireActConditionGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
