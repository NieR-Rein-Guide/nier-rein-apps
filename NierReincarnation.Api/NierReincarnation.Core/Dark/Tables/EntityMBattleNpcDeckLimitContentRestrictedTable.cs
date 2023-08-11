using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckLimitContentRestrictedTable : TableBase<EntityMBattleNpcDeckLimitContentRestricted>
{
    private readonly Func<EntityMBattleNpcDeckLimitContentRestricted, (long, int, int, string)> primaryIndexSelector;

    public EntityMBattleNpcDeckLimitContentRestrictedTable(EntityMBattleNpcDeckLimitContentRestricted[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.EventQuestChapterId, element.QuestId, element.DeckRestrictedUuid);
    }
}
