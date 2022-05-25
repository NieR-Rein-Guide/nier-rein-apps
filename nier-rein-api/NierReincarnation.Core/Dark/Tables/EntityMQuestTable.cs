using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestTable : TableBase<EntityMQuest>
    {
        // Fields
        private readonly Func<EntityMQuest, int> primaryIndexSelector; // 0x18

        public EntityMQuestTable(EntityMQuest[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = quest => quest.QuestId;
        }

        public EntityMQuest FindByQuestId(int key)
        {
            foreach (var quest in data)
                if (primaryIndexSelector(quest) == key)
                    return quest;

            return null;
        }

        public bool TryFindByQuestId(int key, out EntityMQuest result)
        {
            result = FindByQuestId(key);
            return result != null;
        }
    }
}
