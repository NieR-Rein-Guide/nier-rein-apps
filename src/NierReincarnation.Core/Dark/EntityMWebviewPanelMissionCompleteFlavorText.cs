using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWebviewPanelMissionCompleteFlavorText))]
public class EntityMWebviewPanelMissionCompleteFlavorText
{
    [Key(0)]
    public int WebviewPanelMissionCompleteFlavorTextId { get; set; }

    [Key(1)]
    public LanguageType LanguageType { get; set; }

    [Key(2)]
    public string CompleteFlavorText { get; set; }
}
