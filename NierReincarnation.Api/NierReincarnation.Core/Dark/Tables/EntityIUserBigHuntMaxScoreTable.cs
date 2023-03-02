using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserBigHuntMaxScoreTable : TableBase<EntityIUserBigHuntMaxScore> // TypeDefIndex: 12465
    {
        // Fields
        private readonly Func<EntityIUserBigHuntMaxScore, ValueTuple<long, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC2378 Offset: 0x2DC2378 VA: 0x2DC2378
        public EntityIUserBigHuntMaxScoreTable(EntityIUserBigHuntMaxScore[] sortedData):base(sortedData)
        {
            primaryIndexSelector = score => (score.UserId, score.BigHuntBossId);
        }

        // RVA: 0x2DC2478 Offset: 0x2DC2478 VA: 0x2DC2478
        public EntityIUserBigHuntMaxScore FindByUserIdAndBigHuntBossId(ValueTuple<long, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2DC2500 Offset: 0x2DC2500 VA: 0x2DC2500
        public bool TryFindByUserIdAndBigHuntBossId(ValueTuple<long, int> key, out EntityIUserBigHuntMaxScore result)
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
