using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntQuestGroupTable : TableBase<EntityMBigHuntQuestGroup> // TypeDefIndex: 11709
    {
        // Fields
        private readonly Func<EntityMBigHuntQuestGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C47684 Offset: 0x2C47684 VA: 0x2C47684
        public EntityMBigHuntQuestGroupTable(EntityMBigHuntQuestGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.BigHuntQuestGroupId, group.SortOrder);
        }
    }
}
