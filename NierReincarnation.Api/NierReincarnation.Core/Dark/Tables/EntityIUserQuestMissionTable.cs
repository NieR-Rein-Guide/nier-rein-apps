using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserQuestMissionTable : TableBase<EntityIUserQuestMission> // TypeDefIndex: 12585
    {
        // Fields
        private readonly Func<EntityIUserQuestMission, ValueTuple<long, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B7F44 Offset: 0x35B7F44 VA: 0x35B7F44
        public EntityIUserQuestMissionTable(EntityIUserQuestMission[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = mission => (mission.UserId, mission.QuestId, mission.QuestMissionId);
        }

        public EntityIUserQuestMission FindByUserIdAndQuestIdAndQuestMissionId(ValueTuple<long, int, int> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x35B8044 Offset: 0x35B8044 VA: 0x35B8044
        public bool TryFindByUserIdAndQuestIdAndQuestMissionId(ValueTuple<long, int, int> key, out EntityIUserQuestMission result)
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
