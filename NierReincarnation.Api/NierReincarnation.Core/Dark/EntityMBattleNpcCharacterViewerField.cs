using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_character_viewer_field")]
public class EntityMBattleNpcCharacterViewerField
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int CharacterViewerFieldId { get; set; }

    [Key(2)]
    public long ReleaseDatetime { get; set; }
}
