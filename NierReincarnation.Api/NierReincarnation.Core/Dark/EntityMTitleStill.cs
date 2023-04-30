using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_title_still")]
    public class EntityMTitleStill
    {
        [Key(0)]
        public int TitleStillId { get; set; } // 0x10

        [Key(1)]
        public int TitleStillGroupId { get; set; } // 0x14

        [Key(2)]
        public int ReleaseEvaluateConditionId { get; set; } // 0x18

        [Key(3)]
        public TitleStillLogoType TitleStillLogoType { get; set; } // 0x1C

        [Key(4)]
        public string AssetName { get; set; } // 0x20
    }
}
