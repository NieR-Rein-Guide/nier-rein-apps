using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcDeckLimitContentBackupRestored))]
public class EntityMBattleNpcDeckLimitContentBackupRestored
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public DifficultyType DifficultyType { get; set; }
}
