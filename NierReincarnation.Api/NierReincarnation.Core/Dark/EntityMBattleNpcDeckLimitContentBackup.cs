using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_deck_limit_content_backup")]
public class EntityMBattleNpcDeckLimitContentBackup
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public int EventQuestSequenceSortOrder { get; set; }

    [Key(3)]
    public string BattleNpcDeckBackupUuid { get; set; }
}
