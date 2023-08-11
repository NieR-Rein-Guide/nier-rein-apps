using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcWeaponTable : TableBase<EntityMBattleNpcWeapon>
{
    private readonly Func<EntityMBattleNpcWeapon, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcWeaponTable(EntityMBattleNpcWeapon[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcWeaponUuid);
    }

    public EntityMBattleNpcWeapon FindByBattleNpcIdAndBattleNpcWeaponUuid(ValueTuple<long, string> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key);
}
