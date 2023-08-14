using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_progress_ui_type")]
public class EntityMBattleProgressUiType
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int BattleProgressUiTypeId { get; set; }
}
