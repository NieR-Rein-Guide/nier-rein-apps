using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_viewer_field")]
    public class EntityMCharacterViewerField
    {
        [Key(0)]
        public int CharacterViewerFieldId { get; set; } // 0x10

        [Key(1)]
        public int ReleaseEvaluateConditionId { get; set; } // 0x14

        [Key(2)]
        public long PublishDatetime { get; set; } // 0x18

        [Key(3)]
        public int CharacterViewerFieldAssetId { get; set; } // 0x20

        [Key(4)]
        public int AssetBackgroundId { get; set; } // 0x24

        [Key(5)]
        public int SortOrder { get; set; } // 0x28
    }
}
