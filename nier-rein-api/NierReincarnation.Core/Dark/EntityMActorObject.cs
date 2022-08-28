using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor_object")]
    public class EntityMActorObject
    {
        [Key(0)]
        public int ActorObjectId { get; set; } // 0x10
        [Key(1)]
        public int ActorId { get; set; } // 0x14
    }
}