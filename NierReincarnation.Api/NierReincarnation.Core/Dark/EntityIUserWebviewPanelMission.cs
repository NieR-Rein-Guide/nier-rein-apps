using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_webview_panel_mission")]
public class EntityIUserWebviewPanelMission
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int WebviewPanelMissionPageId { get; set; }

    [Key(2)]
    public long RewardReceiveDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
