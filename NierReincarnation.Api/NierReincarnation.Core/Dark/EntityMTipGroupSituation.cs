using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_situation")]
    public class EntityMTipGroupSituation
    {
        [Key(0)]
        public TipSituationType TipSituationType { get; set; }

        [Key(1)]
        public int TipGroupId { get; set; }

        [Key(2)]
        public int Weight { get; set; }

        [Key(3)]
        public int TargetId { get; set; }
    }
}
