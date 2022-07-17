using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusCharacterGroupTable: TableBase<EntityMQuestBonusCharacterGroup> // TypeDefIndex: 12345
    {
        // Fields
        private readonly Func<EntityMQuestBonusCharacterGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D0F45C Offset: 0x2D0F45C VA: 0x2D0F45C
        public EntityMQuestBonusCharacterGroupTable(EntityMQuestBonusCharacterGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestBonusCharacterGroupId, group.CharacterId);
        }

        // RVA: 0x2D0F55C Offset: 0x2D0F55C VA: 0x2D0F55C
        public RangeView<EntityMQuestBonusCharacterGroup> FindRangeByQuestBonusCharacterGroupIdAndCharacterId(
            ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
