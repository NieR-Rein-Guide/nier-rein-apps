using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_bgm_set")]
    public class EntityMBattleBgmSet
    {
        [Key(0)]
        public int BgmSetId { get; set; } // 0x10

        [Key(1)]
        public int TrackNumber { get; set; } // 0x14

        [Key(2)]
        public int BgmAssetId { get; set; } // 0x18

        [Key(3)]
        public int Stem { get; set; } // 0x1C

        [Key(4)]
        public int StartWaveNumber { get; set; } // 0x20
    }
}
