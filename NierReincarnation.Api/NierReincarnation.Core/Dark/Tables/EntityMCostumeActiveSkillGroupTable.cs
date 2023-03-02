using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeActiveSkillGroupTable : TableBase<EntityMCostumeActiveSkillGroup> // TypeDefIndex: 11835
    {
        // Fields
        private readonly Func<EntityMCostumeActiveSkillGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B42EE0 Offset: 0x2B42EE0 VA: 0x2B42EE0
        public EntityMCostumeActiveSkillGroupTable(EntityMCostumeActiveSkillGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.CostumeActiveSkillGroupId, group.CostumeLimitBreakCountLowerLimit);
        }

        // RVA: 0x2B42FE0 Offset: 0x2B42FE0 VA: 0x2B42FE0
        public EntityMCostumeActiveSkillGroup FindByCostumeActiveSkillGroupIdAndCostumeLimitBreakCountLowerLimit(
            ValueTuple<int, int> key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, false);
        }
    }
}
