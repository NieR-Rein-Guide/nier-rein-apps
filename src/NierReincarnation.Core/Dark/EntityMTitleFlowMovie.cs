using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_title_flow_movie")]
public class EntityMTitleFlowMovie
{
    [Key(0)]
    public int TitleFlowMovieId { get; set; }

    [Key(1)]
    public int MovieId { get; set; }

    [Key(2)]
    public long StartDatetime { get; set; }

    [Key(3)]
    public long EndDatetime { get; set; }
}
