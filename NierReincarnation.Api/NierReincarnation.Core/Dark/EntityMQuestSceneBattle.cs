using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_scene_battle")]
public class EntityMQuestSceneBattle
{
    [Key(0)] // RVA: 0x1DE2A1C Offset: 0x1DE2A1C VA: 0x1DE2A1C
    public int QuestSceneId { get; set; }

    [Key(1)] // RVA: 0x1DE2A5C Offset: 0x1DE2A5C VA: 0x1DE2A5C
    public int BattleGroupId { get; set; }

    [Key(2)] // RVA: 0x1DE2A70 Offset: 0x1DE2A70 VA: 0x1DE2A70
    public int BattleDropBoxGroupId { get; set; }

    [Key(3)] // RVA: 0x1DE2A84 Offset: 0x1DE2A84 VA: 0x1DE2A84
    public int BattleFieldLocaleSettingIndex { get; set; }

    [Key(4)] // RVA: 0x1DE2A98 Offset: 0x1DE2A98 VA: 0x1DE2A98
    public int BattleEventGroupId { get; set; }

    [Key(5)] // RVA: 0x1DE2AAC Offset: 0x1DE2AAC VA: 0x1DE2AAC
    public int PostProcessConfigurationIndex { get; set; }
}
