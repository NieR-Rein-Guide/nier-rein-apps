using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeSpecialActActiveSkillTable : TableBase<EntityMCostumeSpecialActActiveSkill>
    {
        private readonly Func<EntityMCostumeSpecialActActiveSkill, int> primaryIndexSelector;

        public EntityMCostumeSpecialActActiveSkillTable(EntityMCostumeSpecialActActiveSkill[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CostumeId;
        }

        public bool TryFindByCostumeId(int key, out EntityMCostumeSpecialActActiveSkill result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
