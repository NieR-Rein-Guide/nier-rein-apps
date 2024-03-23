using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeDisplaySwitch))]
public class EntityMCostumeDisplaySwitch
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int DisplayConditionClearQuestId { get; set; }

    [Key(2)]
    public int DisplayDeletedExpressionAssetId { get; set; }
}
