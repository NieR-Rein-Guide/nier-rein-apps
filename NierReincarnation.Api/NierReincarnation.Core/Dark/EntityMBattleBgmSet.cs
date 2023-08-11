using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_bgm_set")]
    public class EntityMBattleBgmSet
    {
        [Key(0)]
        public int BgmSetId { get; set; }

        [Key(1)]
        public int TrackNumber { get; set; }

        [Key(2)]
        public int BgmAssetId { get; set; }

        [Key(3)]
        public int Stem { get; set; }

        [Key(4)]
        public int StartWaveNumber { get; set; }
    }
}
