using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMainQuestSequenceGroupTable : TableBase<EntityMMainQuestSequenceGroup> // TypeDefIndex: 11995
    {
        // Fields
        private readonly Func<EntityMMainQuestSequenceGroup, (int, DifficultyType)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B4A10C Offset: 0x2B4A10C VA: 0x2B4A10C
        public EntityMMainQuestSequenceGroupTable(EntityMMainQuestSequenceGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.MainQuestSequenceGroupId, group.DifficultyType);
        }

        // RVA: 0x2B4A20C Offset: 0x2B4A20C VA: 0x2B4A20C
        public EntityMMainQuestSequenceGroup FindByMainQuestSequenceGroupIdAndDifficultyType((int, DifficultyType) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
