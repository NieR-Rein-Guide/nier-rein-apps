using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleQuestSceneBgmTable : TableBase<EntityMBattleQuestSceneBgm>
{
    private readonly Func<EntityMBattleQuestSceneBgm, (int, int)> primaryIndexSelector;

    public EntityMBattleQuestSceneBgmTable(EntityMBattleQuestSceneBgm[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestSceneId, element.StartWaveNumber);
    }
}
