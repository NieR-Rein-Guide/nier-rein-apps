using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_content_possession")]
    public class EntityMShopItemContentPossession
    {
        [Key(0)] // RVA: 0x1DDFE8C Offset: 0x1DDFE8C VA: 0x1DDFE8C
        public int ShopItemId { get; set; }
        [Key(1)] // RVA: 0x1DDFECC Offset: 0x1DDFECC VA: 0x1DDFECC
        public PossessionType PossessionType { get; set; }
        [Key(2)] // RVA: 0x1DDFF0C Offset: 0x1DDFF0C VA: 0x1DDFF0C
        public int PossessionId { get; set; }
        [Key(3)] // RVA: 0x1DDFF4C Offset: 0x1DDFF4C VA: 0x1DDFF4C
        public int SortOrder { get; set; }
        [Key(4)] // RVA: 0x1DDFF60 Offset: 0x1DDFF60 VA: 0x1DDFF60
        public int Count { get; set; }
	}
}
