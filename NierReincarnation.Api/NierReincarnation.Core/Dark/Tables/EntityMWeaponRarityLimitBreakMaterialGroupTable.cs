using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponRarityLimitBreakMaterialGroupTable : TableBase<EntityMWeaponRarityLimitBreakMaterialGroup>
{
    private readonly Func<EntityMWeaponRarityLimitBreakMaterialGroup, (RarityType, int)> primaryIndexSelector;

    public EntityMWeaponRarityLimitBreakMaterialGroupTable(EntityMWeaponRarityLimitBreakMaterialGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.RarityType, element.MaterialId);
    }
}
