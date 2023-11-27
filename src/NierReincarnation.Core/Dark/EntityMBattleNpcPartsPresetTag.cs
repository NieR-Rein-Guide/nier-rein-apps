using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcPartsPresetTag))]
public class EntityMBattleNpcPartsPresetTag
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int BattleNpcPartsPresetTagNumber { get; set; }

    [Key(2)]
    public string Name { get; set; }
}
