using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item_effect_target_item_group")]
    public class EntityMImportantItemEffectTargetItemGroup
    {
        [Key(0)]
        public int ImportantItemEffectTargetItemGroupId { get; set; }

        [Key(1)]
        public int TargetIndex { get; set; }

        [Key(2)]
        public PossessionType PossessionType { get; set; }

        [Key(3)]
        public int PossessionId { get; set; }
    }
}
