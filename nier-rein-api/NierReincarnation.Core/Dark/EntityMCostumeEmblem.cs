using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_emblem")]
    public class EntityMCostumeEmblem
    {
        [Key(0)] // RVA: 0x1DD92B4 Offset: 0x1DD92B4 VA: 0x1DD92B4
        public int CostumeEmblemAssetId { get; set; }
        [Key(1)] // RVA: 0x1DD92F4 Offset: 0x1DD92F4 VA: 0x1DD92F4
        public int SortOrder { get; set; }
    }
}
