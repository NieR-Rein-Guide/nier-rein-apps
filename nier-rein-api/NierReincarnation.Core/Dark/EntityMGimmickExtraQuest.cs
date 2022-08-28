using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_extra_quest")]
    public class EntityMGimmickExtraQuest
    {
        [Key(0)]
        public int GimmickId { get; set; } // 0x10
        [Key(1)]
        public int GimmickOrnamentIndex { get; set; } // 0x14
        [Key(2)]
        public int ExtraQuestId { get; set; } // 0x18
    }
}