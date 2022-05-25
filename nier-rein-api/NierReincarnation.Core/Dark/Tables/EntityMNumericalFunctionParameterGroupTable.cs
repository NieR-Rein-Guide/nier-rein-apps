using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMNumericalFunctionParameterGroupTable : TableBase<EntityMNumericalFunctionParameterGroup> // TypeDefIndex: 12029
    {
        // Fields
        private readonly Func<EntityMNumericalFunctionParameterGroup, (int, int)> primaryIndexSelector; // 0x18
        private readonly EntityMNumericalFunctionParameterGroup[] secondaryIndex0; // 0x20
        private readonly Func<EntityMNumericalFunctionParameterGroup, int> secondaryIndex0Selector; // 0x28

        // Methods

        // RVA: 0x2C504D8 Offset: 0x2C504D8 VA: 0x2C504D8
        public EntityMNumericalFunctionParameterGroupTable(EntityMNumericalFunctionParameterGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.NumericalFunctionParameterGroupId, group.ParameterIndex);
            secondaryIndex0Selector = group => group.NumericalFunctionParameterGroupId;
        }

        // RVA: 0x2C50690 Offset: 0x2C50690 VA: 0x2C50690
        public RangeView<EntityMNumericalFunctionParameterGroup> FindByNumericalFunctionParameterGroupId(int key)
        {
            var result = new List<EntityMNumericalFunctionParameterGroup>();
            foreach (var entry in data)
                if (secondaryIndex0Selector(entry) == key)
                    result.Add(entry);

            return new RangeView<EntityMNumericalFunctionParameterGroup>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}
