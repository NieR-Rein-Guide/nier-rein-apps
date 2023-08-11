using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_rebirth_material_group")]
    public class EntityMCharacterRebirthMaterialGroup
    {
        [Key(0)]
        public int CharacterRebirthMaterialGroupId { get; set; }

        [Key(1)]
        public int MaterialId { get; set; }

        [Key(2)]
        public int Count { get; set; }

        [Key(3)]
        public int SortOrder { get; set; }
    }
}
