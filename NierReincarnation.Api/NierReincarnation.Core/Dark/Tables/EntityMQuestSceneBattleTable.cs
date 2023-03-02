using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestSceneBattleTable : TableBase<EntityMQuestSceneBattle> // TypeDefIndex: 12173
    {
        // Fields
        private readonly Func<EntityMQuestSceneBattle, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C5A138 Offset: 0x2C5A138 VA: 0x2C5A138
        public EntityMQuestSceneBattleTable(EntityMQuestSceneBattle[] sortedData):base(sortedData)
        {
            primaryIndexSelector = battle => battle.QuestSceneId;
        }

        // RVA: 0x2C5A238 Offset: 0x2C5A238 VA: 0x2C5A238
        public EntityMQuestSceneBattle FindByQuestSceneId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
