using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalLifetimeBehaviourGroupTable : TableBase<EntityMSkillAbnormalLifetimeBehaviourGroup>
    {
        private readonly Func<EntityMSkillAbnormalLifetimeBehaviourGroup, (int,int)> primaryIndexSelector;

        public EntityMSkillAbnormalLifetimeBehaviourGroupTable(EntityMSkillAbnormalLifetimeBehaviourGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.SkillAbnormalLifetimeBehaviourGroupId,element.AbnormalLifetimeBehaviourIndex);
        }
        
    }
}
