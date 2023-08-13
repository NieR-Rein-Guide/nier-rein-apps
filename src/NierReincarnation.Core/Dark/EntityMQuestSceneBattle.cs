using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_scene_battle")]
public class EntityMQuestSceneBattle
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int BattleGroupId { get; set; }

    [Key(2)]
    public int BattleDropBoxGroupId { get; set; }

    [Key(3)]
    public int BattleFieldLocaleSettingIndex { get; set; }

    [Key(4)]
    public int BattleEventGroupId { get; set; }

    [Key(5)]
    public int PostProcessConfigurationIndex { get; set; }
}
