using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeDefaultSkillGroupTable : TableBase<EntityMCostumeDefaultSkillGroup>
{
    private readonly Func<EntityMCostumeDefaultSkillGroup, (int, CostumeDefaultSkillLotteryType)> primaryIndexSelector;

    public EntityMCostumeDefaultSkillGroupTable(EntityMCostumeDefaultSkillGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeDefaultSkillGroupId, element.CostumeDefaultSkillLotteryType);
    }

    public EntityMCostumeDefaultSkillGroup FindByCostumeDefaultSkillGroupIdAndCostumeDefaultSkillLotteryType(ValueTuple<int, CostumeDefaultSkillLotteryType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, CostumeDefaultSkillLotteryType)>.Default, key);
}
