using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable : TableBase<EntityMSkillAbnormalBehaviourActionAbnormalResistance>
    {
        private readonly Func<EntityMSkillAbnormalBehaviourActionAbnormalResistance, int> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable(EntityMSkillAbnormalBehaviourActionAbnormalResistance[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
        }

        public EntityMSkillAbnormalBehaviourActionAbnormalResistance FindBySkillAbnormalBehaviourActionId(int key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
