using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCharacterViewerField))]
public class EntityMBattleNpcCharacterViewerField
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterViewerFieldId { get; set; }

    [Key(2)]
    public long ReleaseDatetime { get; set; }
}
