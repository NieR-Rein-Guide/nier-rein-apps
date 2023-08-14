using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_webview_panel_mission_page")]
public class EntityMWebviewPanelMissionPage
{
    [Key(0)]
    public int WebviewPanelMissionPageId { get; set; }

    [Key(1)]
    public int WebviewPanelMissionPanelGroupId { get; set; }

    [Key(2)]
    public int WebviewPanelMissionBgPartsGroupId { get; set; }

    [Key(3)]
    public int WebviewPanelMissionCompleteFlavorTextId { get; set; }

    [Key(4)]
    public string ImageFileName { get; set; }

    [Key(5)]
    public int ImageAssetId { get; set; }

    [Key(6)]
    public int WebviewPanelMissionPageRewardGroupId { get; set; }
}
