using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_status_up_group")]
    public class EntityMCostumeAwakenStatusUpGroup
    {
        [Key(0)]
        public int CostumeAwakenStatusUpGroupId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public StatusKindType StatusKindType { get; set; }

        [Key(3)]
        public StatusCalculationType StatusCalculationType { get; set; }

        [Key(4)]
        public int EffectValue { get; set; }
    }
}
