using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcPartsGroupNote))]
public class EntityMBattleNpcPartsGroupNote
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int PartsGroupId { get; set; }

    [Key(2)]
    public long FirstAcquisitionDatetime { get; set; }
}
