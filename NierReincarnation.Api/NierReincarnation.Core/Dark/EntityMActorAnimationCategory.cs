using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_animation_category")]
    public class EntityMActorAnimationCategory
    {
        [Key(0)]
        public int ActorAnimationCategoryId { get; set; } // 0x10
        [Key(1)]
        public string Name { get; set; } // 0x18
    }
}