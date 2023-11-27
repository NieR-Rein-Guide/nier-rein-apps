using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcWeaponNoteReevaluate))]
public class EntityMBattleNpcWeaponNoteReevaluate
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public long LastReevaluateDatetime { get; set; }
}
