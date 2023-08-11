using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeSpecialActActiveSkillConditionAttributeTable : TableBase<EntityMCostumeSpecialActActiveSkillConditionAttribute>
{
    private readonly Func<EntityMCostumeSpecialActActiveSkillConditionAttribute, int> primaryIndexSelector;

    public EntityMCostumeSpecialActActiveSkillConditionAttributeTable(EntityMCostumeSpecialActActiveSkillConditionAttribute[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeSpecialActActiveSkillConditionId;
    }

    public bool TryFindByCostumeSpecialActActiveSkillConditionId(int key, out EntityMCostumeSpecialActActiveSkillConditionAttribute result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
