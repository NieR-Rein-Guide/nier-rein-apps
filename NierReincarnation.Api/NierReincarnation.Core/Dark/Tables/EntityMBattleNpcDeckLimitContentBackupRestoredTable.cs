using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckLimitContentBackupRestoredTable : TableBase<EntityMBattleNpcDeckLimitContentBackupRestored>
{
    private readonly Func<EntityMBattleNpcDeckLimitContentBackupRestored, (long, int)> primaryIndexSelector;

    public EntityMBattleNpcDeckLimitContentBackupRestoredTable(EntityMBattleNpcDeckLimitContentBackupRestored[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.EventQuestChapterId);
    }
}
