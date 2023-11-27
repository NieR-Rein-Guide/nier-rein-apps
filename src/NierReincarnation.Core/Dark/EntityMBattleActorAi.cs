using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleActorAi))]
public class EntityMBattleActorAi
{
    [Key(0)]
    public int BattleActorAiId { get; set; }

    [Key(1)]
    public string AssetPath { get; set; }

    [Key(2)]
    public string Description { get; set; }
}
