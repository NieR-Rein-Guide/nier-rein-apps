using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMainQuestSequenceTable : TableBase<EntityMMainQuestSequence> // TypeDefIndex: 11997
    {
        // Fields
        private readonly Func<EntityMMainQuestSequence, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B4A368 Offset: 0x2B4A368 VA: 0x2B4A368
        public EntityMMainQuestSequenceTable(EntityMMainQuestSequence[] sortedData):base(sortedData)
        {
            primaryIndexSelector = sequence => (sequence.MainQuestSequenceId, sequence.SortOrder);
        }

        // RVA: 0x2B4A468 Offset: 0x2B4A468 VA: 0x2B4A468
        public EntityMMainQuestSequence FindClosestByMainQuestSequenceIdAndSortOrder((int, int) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
        }

        // RVA: 0x2B4A4EC Offset: 0x2B4A4EC VA: 0x2B4A4EC
        public RangeView<EntityMMainQuestSequence> FindRangeByMainQuestSequenceIdAndSortOrder((int, int) min, (int, int) max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
