using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_background")]
    public class EntityMPvpBackground
    {
        [Key(0)]
        public int AssetBackgroundId { get; set; } // 0x10
        [Key(1)]
        public int BattleFieldLocaleSettingIndex { get; set; } // 0x14
        [Key(2)]
        public int BattlePointIndex { get; set; } // 0x18
        [Key(3)]
        public int RandomWeight { get; set; } // 0x1C
        [Key(4)]
        public int PostProcessConfigurationIndex { get; set; } // 0x20
        [Key(5)]
        public int BattleCameraControllerAssetId { get; set; } // 0x24
        [Key(6)]
        public int BattleStartCameraType { get; set; } // 0x28
        [Key(7)]
        public int WaveStartActAssetId { get; set; } // 0x2C
        [Key(8)]
        public int WaveEndActAssetId { get; set; } // 0x30
    }
}