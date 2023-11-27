using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleBgmSetGroup))]
public class EntityMBattleBgmSetGroup
{
    [Key(0)]
    public int BgmSetGroupId { get; set; }

    [Key(1)]
    public int BgmSetGroupIndex { get; set; }

    [Key(2)]
    public int BgmSetId { get; set; }

    [Key(3)]
    public int RandomWeight { get; set; }
}
