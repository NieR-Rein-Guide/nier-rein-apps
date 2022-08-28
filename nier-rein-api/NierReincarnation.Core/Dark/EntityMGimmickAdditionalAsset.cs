using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_additional_asset")]
    public class EntityMGimmickAdditionalAsset
    {
        [Key(0)]
        public int GimmickId { get; set; } // 0x10
        [Key(1)]
        public string GimmickTexturePath { get; set; } // 0x18
    }
}