using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_material_sale_obtain_possession")]
    public class EntityMMaterialSaleObtainPossession
    {
        [Key(0)]
        public int MaterialSaleObtainPossessionId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public PossessionType PossessionType { get; set; }

        [Key(3)]
        public int PossessionId { get; set; }

        [Key(4)]
        public int Count { get; set; }
    }
}
