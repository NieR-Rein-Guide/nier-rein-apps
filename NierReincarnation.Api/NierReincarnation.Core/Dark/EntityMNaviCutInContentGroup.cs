using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_navi_cut_in_content_group")]
public class EntityMNaviCutInContentGroup
{
    [Key(0)]
    public int NaviCutInContentGroupId { get; set; }

    [Key(1)]
    public int ContentIndex { get; set; }

    [Key(2)]
    public int NaviCutInTextId { get; set; }
}
