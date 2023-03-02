using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBigHuntQuestScoreCoefficientTable : TableBase<EntityMBigHuntQuestScoreCoefficient> // TypeDefIndex: 11711
    {
        // Fields
        private readonly Func<EntityMBigHuntQuestScoreCoefficient, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C47860 Offset: 0x2C47860 VA: 0x2C47860
        public EntityMBigHuntQuestScoreCoefficientTable(EntityMBigHuntQuestScoreCoefficient[] sortedData):base(sortedData)
        {
            primaryIndexSelector = coefficient => coefficient.BigHuntQuestScoreCoefficientId;
        }

        // RVA: 0x2C47960 Offset: 0x2C47960 VA: 0x2C47960
        public EntityMBigHuntQuestScoreCoefficient FindByBigHuntQuestScoreCoefficientId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
