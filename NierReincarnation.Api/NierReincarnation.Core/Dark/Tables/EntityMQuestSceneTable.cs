using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestSceneTable : TableBase<EntityMQuestScene> // TypeDefIndex: 12179
    {
        // Fields
        private readonly Func<EntityMQuestScene, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C5A780 Offset: 0x2C5A780 VA: 0x2C5A780
        public EntityMQuestSceneTable(EntityMQuestScene[] sortedData):base(sortedData)
        {
            primaryIndexSelector = scene => scene.QuestSceneId;
        }

        // RVA: 0x2C5A880 Offset: 0x2C5A880 VA: 0x2C5A880
        public EntityMQuestScene FindByQuestSceneId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C5A914 Offset: 0x2C5A914 VA: 0x2C5A914
        public bool TryFindByQuestSceneId(int key, out EntityMQuestScene result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
