using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_parts_status_sub")]
    public class EntityMBattleNpcPartsStatusSub
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public string BattleNpcPartsUuid { get; set; }

        [Key(2)]
        public int StatusIndex { get; set; }

        [Key(3)]
        public int PartsStatusSubLotteryId { get; set; }

        [Key(4)]
        public int Level { get; set; }

        [Key(5)]
        public StatusKindType StatusKindType { get; set; }

        [Key(6)]
        public StatusCalculationType StatusCalculationType { get; set; }

        [Key(7)]
        public int StatusChangeValue { get; set; }
    }
}
