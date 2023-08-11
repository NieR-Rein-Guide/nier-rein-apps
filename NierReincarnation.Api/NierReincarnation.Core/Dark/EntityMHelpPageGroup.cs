using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_help_page_group")]
public class EntityMHelpPageGroup
{
    [Key(0)]
    public int HelpPageGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int HelpPageId { get; set; }
}
