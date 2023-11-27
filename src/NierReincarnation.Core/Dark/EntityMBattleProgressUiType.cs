using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleProgressUiType))]
public class EntityMBattleProgressUiType
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int BattleProgressUiTypeId { get; set; }
}
