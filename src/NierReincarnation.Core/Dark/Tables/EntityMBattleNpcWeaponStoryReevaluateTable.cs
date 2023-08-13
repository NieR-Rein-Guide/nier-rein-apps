using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcWeaponStoryReevaluateTable : TableBase<EntityMBattleNpcWeaponStoryReevaluate>
{
    private readonly Func<EntityMBattleNpcWeaponStoryReevaluate, long> primaryIndexSelector;

    public EntityMBattleNpcWeaponStoryReevaluateTable(EntityMBattleNpcWeaponStoryReevaluate[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleNpcId;
    }
}
