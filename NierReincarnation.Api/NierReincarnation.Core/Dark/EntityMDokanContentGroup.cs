using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_dokan_content_group")]
public class EntityMDokanContentGroup
{
    [Key(0)]
    public int DokanContentGroupId { get; set; }

    [Key(1)]
    public int ContentIndex { get; set; }

    [Key(2)]
    public int ImageId { get; set; }

    [Key(3)]
    public int MovieId { get; set; }

    [Key(4)]
    public int DokanTextId { get; set; }
}
