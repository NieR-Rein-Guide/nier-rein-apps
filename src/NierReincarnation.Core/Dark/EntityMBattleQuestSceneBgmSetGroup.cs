using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleQuestSceneBgmSetGroup))]
public class EntityMBattleQuestSceneBgmSetGroup
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int BgmSetGroupId { get; set; }
}
