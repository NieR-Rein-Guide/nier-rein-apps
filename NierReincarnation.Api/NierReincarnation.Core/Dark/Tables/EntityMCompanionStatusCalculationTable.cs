using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCompanionStatusCalculationTable : TableBase<EntityMCompanionStatusCalculation>
    {
        private readonly Func<EntityMCompanionStatusCalculation, int> primaryIndexSelector;

        public EntityMCompanionStatusCalculationTable(EntityMCompanionStatusCalculation[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CompanionStatusCalculationId;
        }

        public EntityMCompanionStatusCalculation FindByCompanionStatusCalculationId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
