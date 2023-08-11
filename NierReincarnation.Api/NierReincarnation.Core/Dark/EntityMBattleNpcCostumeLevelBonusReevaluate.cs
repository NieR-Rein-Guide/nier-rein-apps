using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_costume_level_bonus_reevaluate")]
    public class EntityMBattleNpcCostumeLevelBonusReevaluate
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public long LastReevaluateDatetime { get; set; }
    }
}
