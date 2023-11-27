using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcWeaponStoryReevaluate))]
public class EntityMBattleNpcWeaponStoryReevaluate
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public long LastReevaluateDatetime { get; set; }
}
