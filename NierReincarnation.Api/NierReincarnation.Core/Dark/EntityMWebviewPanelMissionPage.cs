using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_webview_panel_mission_page")]
    public class EntityMWebviewPanelMissionPage
    {
        [Key(0)]
        public int WebviewPanelMissionPageId { get; set; } // 0x10

        [Key(1)]
        public int WebviewPanelMissionPanelGroupId { get; set; } // 0x14

        [Key(2)]
        public int WebviewPanelMissionBgPartsGroupId { get; set; } // 0x18

        [Key(3)]
        public int WebviewPanelMissionCompleteFlavorTextId { get; set; } // 0x1C

        [Key(4)]
        public string ImageFileName { get; set; } // 0x20

        [Key(5)]
        public int ImageAssetId { get; set; } // 0x28

        [Key(6)]
        public int WebviewPanelMissionPageRewardGroupId { get; set; } // 0x2C
    }
}
