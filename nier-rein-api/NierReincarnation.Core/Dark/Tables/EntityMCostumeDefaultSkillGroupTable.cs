using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeDefaultSkillGroupTable : TableBase<EntityMCostumeDefaultSkillGroup>
    {
        private readonly Func<EntityMCostumeDefaultSkillGroup, (int,int)> primaryIndexSelector;

        public EntityMCostumeDefaultSkillGroupTable(EntityMCostumeDefaultSkillGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeDefaultSkillGroupId,element.CostumeDefaultSkillLotteryType);
        }
        
        public EntityMCostumeDefaultSkillGroup FindByCostumeDefaultSkillGroupIdAndCostumeDefaultSkillLotteryType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
