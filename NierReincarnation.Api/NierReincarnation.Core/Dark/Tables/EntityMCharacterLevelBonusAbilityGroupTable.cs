using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterLevelBonusAbilityGroupTable : TableBase<EntityMCharacterLevelBonusAbilityGroup>
{
    private readonly Func<EntityMCharacterLevelBonusAbilityGroup, (int, int)> primaryIndexSelector;

    public EntityMCharacterLevelBonusAbilityGroupTable(EntityMCharacterLevelBonusAbilityGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CharacterLevelBonusAbilityGroupId, element.ActivationCharacterLevel);
    }

    public RangeView<EntityMCharacterLevelBonusAbilityGroup> FindRangeByCharacterLevelBonusAbilityGroupIdAndActivationCharacterLevel(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
