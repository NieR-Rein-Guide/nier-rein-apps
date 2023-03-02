using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestSequenceGroupTable : TableBase<EntityMEventQuestSequenceGroup> // TypeDefIndex: 11894
    {
        // Fields
        private readonly Func<EntityMEventQuestSequenceGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B57C58 Offset: 0x2B57C58 VA: 0x2B57C58
        public EntityMEventQuestSequenceGroupTable(EntityMEventQuestSequenceGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.EventQuestSequenceGroupId, (int)group.DifficultyType);
        }

        // RVA: 0x2B57D58 Offset: 0x2B57D58 VA: 0x2B57D58
        public EntityMEventQuestSequenceGroup FindByEventQuestSequenceGroupIdAndDifficultyType((int, int) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
        }

        public RangeView<EntityMEventQuestSequenceGroup> FindRangeByEventQuestSequenceGroupIdAndDifficultyType((int, int) min, (int, int) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
