using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourGroupTable : TableBase<EntityMSkillAbnormalBehaviourGroup>
    {
        private readonly Func<EntityMSkillAbnormalBehaviourGroup, (int,int)> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourGroupTable(EntityMSkillAbnormalBehaviourGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.SkillAbnormalBehaviourGroupId,element.AbnormalBehaviourIndex);
        }
        
    }
}
