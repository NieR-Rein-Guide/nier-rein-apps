using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestBonusTable : TableBase<EntityMQuestBonus> // TypeDefIndex: 12357
    {
        // Fields
        private readonly Func<EntityMQuestBonus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D1020C Offset: 0x2D1020C VA: 0x2D1020C
        public EntityMQuestBonusTable(EntityMQuestBonus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = bonus => bonus.QuestBonusId;
        }

        // RVA: 0x2D1030C Offset: 0x2D1030C VA: 0x2D1030C
        public EntityMQuestBonus FindByQuestBonusId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
