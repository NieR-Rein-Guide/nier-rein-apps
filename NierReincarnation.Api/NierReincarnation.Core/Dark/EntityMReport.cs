using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_report")]
public class EntityMReport
{
    [Key(0)]
    public int ReportId { get; set; }

    [Key(1)]
    public int MainQuestSeasonId { get; set; }

    [Key(2)]
    public int CharacterId { get; set; }

    [Key(3)]
    public int ReportNumber { get; set; }

    [Key(4)]
    public int ReportAssetId { get; set; }
}
