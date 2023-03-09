using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_step_material_group")]
    public class EntityMCostumeAwakenStepMaterialGroup
    {
        [Key(0)]
        public int CostumeAwakenStepMaterialGroupId { get; set; } // 0x10
        [Key(1)]
        public int AwakenStepLowerLimit { get; set; } // 0x14
        [Key(2)]
        public int CostumeAwakenMaterialGroupId { get; set; } // 0x18
    }
}