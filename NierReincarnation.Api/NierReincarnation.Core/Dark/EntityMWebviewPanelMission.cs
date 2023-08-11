using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_webview_panel_mission")]
public class EntityMWebviewPanelMission
{
    [Key(0)]
    public int WebviewPanelMissionId { get; set; }

    [Key(1)]
    public int Page { get; set; }

    [Key(2)]
    public int WebviewPanelMissionPageId { get; set; }

    [Key(3)]
    public long StartDatetime { get; set; }

    [Key(4)]
    public long EndDatetime { get; set; }
}
