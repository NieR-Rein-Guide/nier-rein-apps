using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_character_viewer_field")]
    public class EntityMBattleNpcCharacterViewerField
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int CharacterViewerFieldId { get; set; } // 0x18
        [Key(2)]
        public long ReleaseDatetime { get; set; } // 0x20
    }
}