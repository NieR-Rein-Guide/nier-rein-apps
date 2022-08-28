using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_costume_level_bonus_release_status")]
    public class EntityMBattleNpcCostumeLevelBonusReleaseStatus
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int CostumeId { get; set; } // 0x18
        [Key(2)]
        public int LastReleasedBonusLevel { get; set; } // 0x1C
        [Key(3)]
        public int ConfirmedBonusLevel { get; set; } // 0x20
    }
}