using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_speaker")]
    public class EntityMSpeaker
    {
        [Key(0)]
        public int ActorObjectId { get; set; } // 0x10
        [Key(1)]
        public int NameSpeakerTextId { get; set; } // 0x14
        [Key(2)]
        public int SpeakerIconType { get; set; } // 0x18
        [Key(3)]
        public int SpeakerIconIndex { get; set; } // 0x1C
    }
}