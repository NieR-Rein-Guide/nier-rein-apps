using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_webview_panel_mission_complete_flavor_text")]
public class EntityMWebviewPanelMissionCompleteFlavorText
{
    [Key(0)]
    public int WebviewPanelMissionCompleteFlavorTextId { get; set; }

    [Key(1)]
    public LanguageType LanguageType { get; set; }

    [Key(2)]
    public string CompleteFlavorText { get; set; }
}
