using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpc))]
public class EntityMBattleNpc
{
    [Key(0)]
    public long BattleNpcId { get; set; }
}
