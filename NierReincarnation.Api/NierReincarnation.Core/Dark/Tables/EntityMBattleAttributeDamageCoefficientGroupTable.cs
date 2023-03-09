using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleAttributeDamageCoefficientGroupTable : TableBase<EntityMBattleAttributeDamageCoefficientGroup>
    {
        private readonly Func<EntityMBattleAttributeDamageCoefficientGroup, (int,int,int)> primaryIndexSelector;

        public EntityMBattleAttributeDamageCoefficientGroupTable(EntityMBattleAttributeDamageCoefficientGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.AttributeDamageCoefficientGroupId,element.SkillExecutorAttributeType,element.SkillTargetAttributeType);
        }
        
    }
}
