using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_catalog_weapon")]
    public class EntityMCatalogWeapon
    {
        [Key(0)] // RVA: 0x1DD6D78 Offset: 0x1DD6D78 VA: 0x1DD6D78
        public int WeaponId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD6DB8 Offset: 0x1DD6DB8 VA: 0x1DD6DB8
        public int SortOrder { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DD6DCC Offset: 0x1DD6DCC VA: 0x1DD6DCC
        public int CatalogTermId { get; set; } // 0x18
    }
}
