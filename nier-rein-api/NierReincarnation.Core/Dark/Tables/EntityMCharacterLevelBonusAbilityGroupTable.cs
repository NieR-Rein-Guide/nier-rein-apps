using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterLevelBonusAbilityGroupTable : TableBase<EntityMCharacterLevelBonusAbilityGroup> // TypeDefIndex: 11781
    {
        // Fields
        private readonly Func<EntityMCharacterLevelBonusAbilityGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B3F088 Offset: 0x2B3F088 VA: 0x2B3F088
        public EntityMCharacterLevelBonusAbilityGroupTable(EntityMCharacterLevelBonusAbilityGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.CharacterLevelBonusAbilityGroupId, group.ActivationCharacterLevel);
        }

        // RVA: 0x2B3F188 Offset: 0x2B3F188 VA: 0x2B3F188
        public RangeView<EntityMCharacterLevelBonusAbilityGroup> FindRangeByCharacterLevelBonusAbilityGroupIdAndActivationCharacterLevel(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
