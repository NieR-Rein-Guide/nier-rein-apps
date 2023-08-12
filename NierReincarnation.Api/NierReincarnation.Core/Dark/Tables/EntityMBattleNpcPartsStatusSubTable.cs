using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcPartsStatusSubTable : TableBase<EntityMBattleNpcPartsStatusSub>
{
    private readonly Func<EntityMBattleNpcPartsStatusSub, (long, string, int)> primaryIndexSelector;

    public EntityMBattleNpcPartsStatusSubTable(EntityMBattleNpcPartsStatusSub[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcPartsUuid, element.StatusIndex);
    }
}
