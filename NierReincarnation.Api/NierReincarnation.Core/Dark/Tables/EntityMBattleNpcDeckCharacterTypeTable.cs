using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckCharacterTypeTable : TableBase<EntityMBattleNpcDeckCharacterType>
{
    private readonly Func<EntityMBattleNpcDeckCharacterType, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcDeckCharacterTypeTable(EntityMBattleNpcDeckCharacterType[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcDeckCharacterUuid);
    }

    public EntityMBattleNpcDeckCharacterType FindByBattleNpcIdAndBattleNpcDeckCharacterUuid(ValueTuple<long, string> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key);
}
