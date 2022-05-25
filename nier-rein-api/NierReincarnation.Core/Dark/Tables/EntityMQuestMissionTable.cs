using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestMissionTable : TableBase<EntityMQuestMission> // TypeDefIndex: 12149
    {
        // Fields
        private readonly Func<EntityMQuestMission, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C586A4 Offset: 0x2C586A4 VA: 0x2C586A4
        public EntityMQuestMissionTable(EntityMQuestMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = mission => mission.QuestMissionId;
        }

        // RVA: 0x2C587A4 Offset: 0x2C587A4 VA: 0x2C587A4
        public EntityMQuestMission FindByQuestMissionId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
