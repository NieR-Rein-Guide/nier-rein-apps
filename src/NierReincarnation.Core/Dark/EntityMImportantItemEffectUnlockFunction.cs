using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMImportantItemEffectUnlockFunction))]
public class EntityMImportantItemEffectUnlockFunction
{
    [Key(0)]
    public int ImportantItemEffectUnlockFunctionId { get; set; }

    [Key(1)]
    public int ImportantItemEffectUnlockFunctionType { get; set; }

    [Key(2)]
    public int UnlockFunctionEffectValue { get; set; }
}
