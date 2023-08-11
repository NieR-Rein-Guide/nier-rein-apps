using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckBackupTable : TableBase<EntityMBattleNpcDeckBackup>
{
    private readonly Func<EntityMBattleNpcDeckBackup, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcDeckBackupTable(EntityMBattleNpcDeckBackup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcDeckBackupUuid);
    }
}
