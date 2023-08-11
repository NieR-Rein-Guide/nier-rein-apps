using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_animation")]
    public class EntityMActorAnimation
    {
        [Key(0)]
        public int ActorAnimationId { get; set; }

        [Key(1)]
        public int ActorId { get; set; }

        [Key(2)]
        public int ActorAnimationCategoryId { get; set; }

        [Key(3)]
        public int ActorAnimationType { get; set; }

        [Key(4)]
        public string AssetPath { get; set; }

        [Key(5)]
        public bool IsDefault { get; set; }
    }
}
