using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestReleaseConditionBigHuntScoreTable : TableBase<EntityMQuestReleaseConditionBigHuntScore> // TypeDefIndex: 12155
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionBigHuntScore, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58D98 Offset: 0x2C58D98 VA: 0x2C58D98
        public EntityMQuestReleaseConditionBigHuntScoreTable(EntityMQuestReleaseConditionBigHuntScore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = score => score.QuestReleaseConditionId;
        }

        // RVA: 0x2C58E98 Offset: 0x2C58E98 VA: 0x2C58E98
        public EntityMQuestReleaseConditionBigHuntScore FindByQuestReleaseConditionId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
