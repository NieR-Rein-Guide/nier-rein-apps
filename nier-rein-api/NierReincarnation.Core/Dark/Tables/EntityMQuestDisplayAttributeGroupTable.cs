using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestDisplayAttributeGroupTable : TableBase<EntityMQuestDisplayAttributeGroup> // TypeDefIndex: 12139
    {
        // Fields
        private readonly Func<EntityMQuestDisplayAttributeGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C57BA0 Offset: 0x2C57BA0 VA: 0x2C57BA0
        public EntityMQuestDisplayAttributeGroupTable(EntityMQuestDisplayAttributeGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestDisplayAttributeGroupId, group.SortOrder);
        }
    }
}
