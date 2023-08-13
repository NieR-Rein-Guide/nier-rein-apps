using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_quest_scene_bgm")]
public class EntityMBattleQuestSceneBgm
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int StartWaveNumber { get; set; }

    [Key(2)]
    public int BgmId { get; set; }

    [Key(3)]
    public int Stem { get; set; }

    [Key(4)]
    public int TrackNumber { get; set; }
}
