using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_limited_open_text_group")]
    public class EntityMLimitedOpenTextGroup
    {
        [Key(0)]
        public int LimitedOpenTextGroupId { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public LimitedOpenTextDisplayConditionType LimitedOpenTextDisplayConditionType { get; set; } // 0x18

        [Key(3)]
        public int LimitedOpenTextDisplayConditionValue { get; set; } // 0x1C

        [Key(4)]
        public int TextAssetId { get; set; } // 0x20
    }
}
