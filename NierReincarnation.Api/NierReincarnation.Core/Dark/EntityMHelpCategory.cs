using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_help_category")]
public class EntityMHelpCategory
{
    [Key(0)]
    public int HelpCategoryId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int TitleTextAssetId { get; set; }

    [Key(3)]
    public bool IsHiddenOnList { get; set; }
}
