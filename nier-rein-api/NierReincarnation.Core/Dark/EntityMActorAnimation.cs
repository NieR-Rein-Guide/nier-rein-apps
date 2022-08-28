using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_animation")]
    public class EntityMActorAnimation
    {
        [Key(0)]
        public int ActorAnimationId { get; set; } // 0x10
        [Key(1)]
        public int ActorId { get; set; } // 0x14
        [Key(2)]
        public int ActorAnimationCategoryId { get; set; } // 0x18
        [Key(3)]
        public int ActorAnimationType { get; set; } // 0x1C
        [Key(4)]
        public string AssetPath { get; set; } // 0x20
        [Key(5)]
        public bool IsDefault { get; set; } // 0x28
    }
}