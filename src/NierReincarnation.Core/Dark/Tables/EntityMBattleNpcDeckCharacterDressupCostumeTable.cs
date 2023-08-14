using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckCharacterDressupCostumeTable : TableBase<EntityMBattleNpcDeckCharacterDressupCostume>
{
    private readonly Func<EntityMBattleNpcDeckCharacterDressupCostume, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcDeckCharacterDressupCostumeTable(EntityMBattleNpcDeckCharacterDressupCostume[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcDeckCharacterUuid);
    }
}
