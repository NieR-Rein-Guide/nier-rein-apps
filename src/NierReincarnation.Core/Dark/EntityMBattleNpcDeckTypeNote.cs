using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcDeckTypeNote))]
public class EntityMBattleNpcDeckTypeNote
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public DeckType DeckType { get; set; }

    [Key(2)]
    public int MaxDeckPower { get; set; }
}
