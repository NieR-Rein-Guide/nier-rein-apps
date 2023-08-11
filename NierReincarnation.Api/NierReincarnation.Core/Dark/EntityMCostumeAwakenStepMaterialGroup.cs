using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_awaken_step_material_group")]
public class EntityMCostumeAwakenStepMaterialGroup
{
    [Key(0)]
    public int CostumeAwakenStepMaterialGroupId { get; set; }

    [Key(1)]
    public int AwakenStepLowerLimit { get; set; }

    [Key(2)]
    public int CostumeAwakenMaterialGroupId { get; set; }
}
