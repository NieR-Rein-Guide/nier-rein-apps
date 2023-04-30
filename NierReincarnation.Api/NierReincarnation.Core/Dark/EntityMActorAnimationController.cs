using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_animation_controller")]
    public class EntityMActorAnimationController
    {
        [Key(0)]
        public int ActorAnimationControllerId { get; set; } // 0x10

        [Key(1)]
        public int ActorId { get; set; } // 0x14

        [Key(2)]
        public int ActorAnimationControllerType { get; set; } // 0x18

        [Key(3)]
        public string AssetPath { get; set; } // 0x20
    }
}
