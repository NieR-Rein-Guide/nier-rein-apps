using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCharacterRebirthTable : TableBase<EntityMBattleNpcCharacterRebirth>
{
    private readonly Func<EntityMBattleNpcCharacterRebirth, (long, int)> primaryIndexSelector;

    public EntityMBattleNpcCharacterRebirthTable(EntityMBattleNpcCharacterRebirth[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.CharacterId);
    }
}
