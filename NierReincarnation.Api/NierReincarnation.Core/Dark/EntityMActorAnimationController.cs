using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_animation_controller")]
    public class EntityMActorAnimationController
    {
        [Key(0)]
        public int ActorAnimationControllerId { get; set; }

        [Key(1)]
        public int ActorId { get; set; }

        [Key(2)]
        public int ActorAnimationControllerType { get; set; }

        [Key(3)]
        public string AssetPath { get; set; }
    }
}
