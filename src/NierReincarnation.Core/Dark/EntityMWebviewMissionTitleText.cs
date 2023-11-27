using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWebviewMissionTitleText))]
public class EntityMWebviewMissionTitleText
{
    [Key(0)]
    public int WebviewMissionTitleTextId { get; set; }

    [Key(1)]
    public LanguageType LanguageType { get; set; }

    [Key(2)]
    public string Text { get; set; }
}
