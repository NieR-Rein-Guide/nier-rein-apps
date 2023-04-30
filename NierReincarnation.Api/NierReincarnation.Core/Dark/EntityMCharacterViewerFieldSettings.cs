using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_viewer_field_settings")]
    public class EntityMCharacterViewerFieldSettings
    {
        [Key(0)]
        public int AssetBackgroundId { get; set; } // 0x10

        [Key(1)]
        public int BgmAssetId { get; set; } // 0x14

        [Key(2)]
        public int Stem { get; set; } // 0x18

        [Key(3)]
        public int BattleFieldLocaleSettingIndex { get; set; } // 0x1C

        [Key(4)]
        public int PostProcessConfigurationIndex { get; set; } // 0x20

        [Key(5)]
        public int BattlePointIndex { get; set; } // 0x24
    }
}
