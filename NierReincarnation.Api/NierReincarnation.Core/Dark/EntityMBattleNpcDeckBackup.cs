using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_backup")]
    public class EntityMBattleNpcDeckBackup
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public string BattleNpcDeckBackupUuid { get; set; }

        [Key(2)]
        public string DeckJson { get; set; }
    }
}
