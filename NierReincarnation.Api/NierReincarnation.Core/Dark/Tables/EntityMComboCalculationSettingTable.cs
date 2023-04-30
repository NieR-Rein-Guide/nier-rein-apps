using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMComboCalculationSettingTable : TableBase<EntityMComboCalculationSetting>
    {
        private readonly Func<EntityMComboCalculationSetting, int> primaryIndexSelector;

        public EntityMComboCalculationSettingTable(EntityMComboCalculationSetting[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ComboCountLowerLimit;
        }
    }
}
