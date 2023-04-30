using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_rebirth_material_group")]
    public class EntityMCharacterRebirthMaterialGroup
    {
        [Key(0)]
        public int CharacterRebirthMaterialGroupId { get; set; } // 0x10

        [Key(1)]
        public int MaterialId { get; set; } // 0x14

        [Key(2)]
        public int Count { get; set; } // 0x18

        [Key(3)]
        public int SortOrder { get; set; } // 0x1C
    }
}
