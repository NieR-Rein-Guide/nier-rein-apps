using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_costume_level_bonus_reevaluate")]
    public class EntityMBattleNpcCostumeLevelBonusReevaluate
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public long LastReevaluateDatetime { get; set; } // 0x18
    }
}
