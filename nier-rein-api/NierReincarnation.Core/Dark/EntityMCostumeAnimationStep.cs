using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_animation_step")]
    public class EntityMCostumeAnimationStep
    {
        [Key(0)]
        public int CostumeId { get; set; } // 0x10
        [Key(1)]
        public int Step { get; set; } // 0x14
        [Key(2)]
        public int ActorAnimationId { get; set; } // 0x18
    }
}