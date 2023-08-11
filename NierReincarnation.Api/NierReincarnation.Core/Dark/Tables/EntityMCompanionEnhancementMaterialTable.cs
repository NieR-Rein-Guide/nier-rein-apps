using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCompanionEnhancementMaterialTable : TableBase<EntityMCompanionEnhancementMaterial>
{
    private readonly Func<EntityMCompanionEnhancementMaterial, (int, int, int)> primaryIndexSelector;

    public EntityMCompanionEnhancementMaterialTable(EntityMCompanionEnhancementMaterial[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CompanionCategoryType, element.Level, element.MaterialId);
    }
}
