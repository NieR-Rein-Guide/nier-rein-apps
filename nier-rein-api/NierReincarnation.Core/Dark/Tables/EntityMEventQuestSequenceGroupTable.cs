using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestSequenceGroupTable : TableBase<EntityMEventQuestSequenceGroup> // TypeDefIndex: 11894
    {
        // Fields
        private readonly Func<EntityMEventQuestSequenceGroup, (int, DifficultyType)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B57C58 Offset: 0x2B57C58 VA: 0x2B57C58
        public EntityMEventQuestSequenceGroupTable(EntityMEventQuestSequenceGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.EventQuestSequenceGroupId, group.DifficultyType);
        }

        // RVA: 0x2B57D58 Offset: 0x2B57D58 VA: 0x2B57D58
        public EntityMEventQuestSequenceGroup FindByEventQuestSequenceGroupIdAndDifficultyType((int, DifficultyType) key)
        {
            foreach (var item in data)
                if (primaryIndexSelector(item) == key)
                    return item;

            return default;
        }
    }
}
