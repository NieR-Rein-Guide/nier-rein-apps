using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeLimitBreakMaterialRarityGroupTable : TableBase<EntityMCostumeLimitBreakMaterialRarityGroup>
    {
        private readonly Func<EntityMCostumeLimitBreakMaterialRarityGroup, (int, int)> primaryIndexSelector;

        public EntityMCostumeLimitBreakMaterialRarityGroupTable(EntityMCostumeLimitBreakMaterialRarityGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeLimitBreakMaterialRarityGroupId, element.MaterialId);
        }
    }
}
