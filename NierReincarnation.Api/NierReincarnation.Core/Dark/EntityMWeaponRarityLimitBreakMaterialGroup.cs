using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_rarity_limit_break_material_group")]
    public class EntityMWeaponRarityLimitBreakMaterialGroup
    {
        [Key(0)]
        public RarityType RarityType { get; set; }

        [Key(1)]
        public int MaterialId { get; set; }

        [Key(2)]
        public int Count { get; set; }

        [Key(3)]
        public int SortOrder { get; set; }
    }
}
