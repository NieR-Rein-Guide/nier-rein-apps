using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_webview_mission_title_text")]
    public class EntityMWebviewMissionTitleText
    {
        [Key(0)]
        public int WebviewMissionTitleTextId { get; set; } // 0x10
        [Key(1)]
        public int LanguageType { get; set; } // 0x14
        [Key(2)]
        public string Text { get; set; } // 0x18
    }
}