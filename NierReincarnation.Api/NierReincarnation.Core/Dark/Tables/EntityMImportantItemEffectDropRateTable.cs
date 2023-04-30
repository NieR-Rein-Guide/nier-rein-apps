using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMImportantItemEffectDropRateTable : TableBase<EntityMImportantItemEffectDropRate>
    {
        private readonly Func<EntityMImportantItemEffectDropRate, int> primaryIndexSelector;

        public EntityMImportantItemEffectDropRateTable(EntityMImportantItemEffectDropRate[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ImportantItemEffectDropRateId;
        }
    }
}
