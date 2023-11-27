using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMDokanText))]
public class EntityMDokanText
{
    [Key(0)]
    public int DokanTextId { get; set; }

    [Key(1)]
    public LanguageType LanguageType { get; set; }

    [Key(2)]
    public string Text { get; set; }
}
