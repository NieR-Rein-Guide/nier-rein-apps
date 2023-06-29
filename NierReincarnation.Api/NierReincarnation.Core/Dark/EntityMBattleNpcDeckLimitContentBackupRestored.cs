using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_limit_content_backup_restored")]
    public class EntityMBattleNpcDeckLimitContentBackupRestored
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18

        [Key(2)]
        public DifficultyType DifficultyType { get; set; } // 0x1C
    }
}
