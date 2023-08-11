using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame;

public static class CalculatorMaterial
{
    private static EntityMMaterial GetEntityMMaterial(int materialId)
    {
        var table = DatabaseDefine.Master.EntityMMaterialTable;
        return table.FindByMaterialId(materialId);
    }

    private static string GetName(int categoryId, int variationId)
    {
        return string.Format(UserInterfaceTextKey.Material.kName, categoryId, variationId).Localize();
    }

    public static string MaterialName(int id)
    {
        var masterMaterial = GetEntityMMaterial(id);
        if (masterMaterial == null)
            return null;

        return GetName(masterMaterial.AssetCategoryId, masterMaterial.AssetVariationId);
    }
}
