using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_actor")]
    public class EntityMActor
    {
        [Key(0)]
        public int ActorId { get; set; } // 0x10

        [Key(1)]
        public int NameActorTextId { get; set; } // 0x14

        [Key(2)]
        public string ActorAssetId { get; set; } // 0x18

        [Key(3)]
        public string ActorSpeakerIconAssetPath { get; set; } // 0x20

        [Key(4)]
        public string AnimatorAssetPath { get; set; } // 0x28
    }
}
