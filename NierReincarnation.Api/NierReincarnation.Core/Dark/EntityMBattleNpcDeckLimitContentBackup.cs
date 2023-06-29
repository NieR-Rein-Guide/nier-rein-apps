using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_limit_content_backup")]
    public class EntityMBattleNpcDeckLimitContentBackup
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18

        [Key(2)]
        public int EventQuestSequenceSortOrder { get; set; } // 0x1C

        [Key(3)]
        public string BattleNpcDeckBackupUuid { get; set; } // 0x20
    }
}
