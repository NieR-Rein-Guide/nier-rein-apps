using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_webview_panel_mission_complete_flavor_text")]
    public class EntityMWebviewPanelMissionCompleteFlavorText
    {
        [Key(0)]
        public int WebviewPanelMissionCompleteFlavorTextId { get; set; } // 0x10
        [Key(1)]
        public LanguageType LanguageType { get; set; } // 0x14
        [Key(2)]
        public string CompleteFlavorText { get; set; } // 0x18
    }
}