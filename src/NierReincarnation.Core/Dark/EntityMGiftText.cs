using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMGiftText))]
public class EntityMGiftText
{
    [Key(0)]
    public int GiftTextId { get; set; }

    [Key(1)]
    public LanguageType LanguageType { get; set; }

    [Key(2)]
    public string Text { get; set; }
}
