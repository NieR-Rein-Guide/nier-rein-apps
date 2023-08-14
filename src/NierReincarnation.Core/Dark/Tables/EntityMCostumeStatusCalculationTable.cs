using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeStatusCalculationTable : TableBase<EntityMCostumeStatusCalculation>
{
    private readonly Func<EntityMCostumeStatusCalculation, int> primaryIndexSelector;

    public EntityMCostumeStatusCalculationTable(EntityMCostumeStatusCalculation[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeStatusCalculationId;
    }

    public EntityMCostumeStatusCalculation FindByCostumeStatusCalculationId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
