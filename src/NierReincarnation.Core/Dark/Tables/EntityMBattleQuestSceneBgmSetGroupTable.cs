using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleQuestSceneBgmSetGroupTable : TableBase<EntityMBattleQuestSceneBgmSetGroup>
{
    private readonly Func<EntityMBattleQuestSceneBgmSetGroup, int> primaryIndexSelector;

    public EntityMBattleQuestSceneBgmSetGroupTable(EntityMBattleQuestSceneBgmSetGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestSceneId;
    }

    public EntityMBattleQuestSceneBgmSetGroup FindByQuestSceneId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
