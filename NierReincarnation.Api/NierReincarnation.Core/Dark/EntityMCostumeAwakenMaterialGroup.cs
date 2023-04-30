using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_material_group")]
    public class EntityMCostumeAwakenMaterialGroup
    {
        [Key(0)]
        public int CostumeAwakenMaterialGroupId { get; set; } // 0x10

        [Key(1)]
        public int MaterialId { get; set; } // 0x14

        [Key(2)]
        public int Count { get; set; } // 0x18

        [Key(3)]
        public int SortOrder { get; set; } // 0x1C
    }
}
