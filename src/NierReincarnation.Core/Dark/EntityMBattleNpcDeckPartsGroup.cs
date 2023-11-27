using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcDeckPartsGroup))]
public class EntityMBattleNpcDeckPartsGroup
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public string BattleNpcDeckCharacterUuid { get; set; }

    [Key(2)]
    public string BattleNpcPartsUuid { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}
