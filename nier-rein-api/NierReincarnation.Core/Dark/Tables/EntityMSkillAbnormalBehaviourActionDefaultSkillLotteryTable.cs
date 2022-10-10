using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable : TableBase<EntityMSkillAbnormalBehaviourActionDefaultSkillLottery>
    {
        private readonly Func<EntityMSkillAbnormalBehaviourActionDefaultSkillLottery, int> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable(EntityMSkillAbnormalBehaviourActionDefaultSkillLottery[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
        }
        
        public EntityMSkillAbnormalBehaviourActionDefaultSkillLottery FindBySkillAbnormalBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}