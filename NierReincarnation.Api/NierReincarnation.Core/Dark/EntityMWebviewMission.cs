using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_webview_mission")]
    public class EntityMWebviewMission
    {
        [Key(0)]
        public int WebviewMissionId { get; set; } // 0x10
        [Key(1)]
        public int TitleTextId { get; set; } // 0x14
        [Key(2)]
        public int WebviewMissionType { get; set; } // 0x18
        [Key(3)]
        public int WebviewMissionTargetId { get; set; } // 0x1C
        [Key(4)]
        public long StartDatetime { get; set; } // 0x20
        [Key(5)]
        public long EndDatetime { get; set; } // 0x28
    }
}