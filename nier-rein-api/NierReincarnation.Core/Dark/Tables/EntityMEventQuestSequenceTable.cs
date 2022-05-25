using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMEventQuestSequenceTable : TableBase<EntityMEventQuestSequence> // TypeDefIndex: 11896
    {
        // Fields
        private readonly Func<EntityMEventQuestSequence, (int,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B57EB4 Offset: 0x2B57EB4 VA: 0x2B57EB4
        public EntityMEventQuestSequenceTable(EntityMEventQuestSequence[] sortedData):base(sortedData)
        {
            primaryIndexSelector = sequence => (sequence.EventQuestSequenceId, sequence.SortOrder);
        }

        // RVA: 0x2B57FB4 Offset: 0x2B57FB4 VA: 0x2B57FB4
        public RangeView<EntityMEventQuestSequence> FindRangeByEventQuestSequenceIdAndSortOrder((int, int) min, (int, int) max, bool ascendant = true)
        {
            throw new NotImplementedException();
        }
    }
}
