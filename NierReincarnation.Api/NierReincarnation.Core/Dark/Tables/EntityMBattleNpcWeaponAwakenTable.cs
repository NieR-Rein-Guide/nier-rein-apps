using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcWeaponAwakenTable : TableBase<EntityMBattleNpcWeaponAwaken>
{
    private readonly Func<EntityMBattleNpcWeaponAwaken, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcWeaponAwakenTable(EntityMBattleNpcWeaponAwaken[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcWeaponUuid);
    }
}
