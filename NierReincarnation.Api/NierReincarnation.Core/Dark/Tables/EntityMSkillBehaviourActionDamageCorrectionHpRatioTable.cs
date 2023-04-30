using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionDamageCorrectionHpRatioTable : TableBase<EntityMSkillBehaviourActionDamageCorrectionHpRatio>
    {
        private readonly Func<EntityMSkillBehaviourActionDamageCorrectionHpRatio, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionDamageCorrectionHpRatioTable(EntityMSkillBehaviourActionDamageCorrectionHpRatio[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public EntityMSkillBehaviourActionDamageCorrectionHpRatio FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
