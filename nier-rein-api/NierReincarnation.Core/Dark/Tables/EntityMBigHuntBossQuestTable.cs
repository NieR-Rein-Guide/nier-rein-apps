using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntBossQuestTable : TableBase<EntityMBigHuntBossQuest> // TypeDefIndex: 11703
    {
        // Fields
        private readonly Func<EntityMBigHuntBossQuest, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C470D0 Offset: 0x2C470D0 VA: 0x2C470D0
        public EntityMBigHuntBossQuestTable(EntityMBigHuntBossQuest[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = quest => quest.BigHuntBossQuestId;
        }

        // RVA: 0x2C471D0 Offset: 0x2C471D0 VA: 0x2C471D0
        public EntityMBigHuntBossQuest FindByBigHuntBossQuestId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
