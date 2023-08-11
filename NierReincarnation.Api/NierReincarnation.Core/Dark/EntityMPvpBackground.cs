using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_background")]
    public class EntityMPvpBackground
    {
        [Key(0)]
        public int AssetBackgroundId { get; set; }

        [Key(1)]
        public int BattleFieldLocaleSettingIndex { get; set; }

        [Key(2)]
        public int BattlePointIndex { get; set; }

        [Key(3)]
        public int RandomWeight { get; set; }

        [Key(4)]
        public int PostProcessConfigurationIndex { get; set; }

        [Key(5)]
        public int BattleCameraControllerAssetId { get; set; }

        [Key(6)]
        public BattleStartCameraType BattleStartCameraType { get; set; }

        [Key(7)]
        public int WaveStartActAssetId { get; set; }

        [Key(8)]
        public int WaveEndActAssetId { get; set; }
    }
}
