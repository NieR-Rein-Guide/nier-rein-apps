using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_speaker")]
    public class EntityMSpeaker
    {
        [Key(0)]
        public int ActorObjectId { get; set; }

        [Key(1)]
        public int NameSpeakerTextId { get; set; }

        [Key(2)]
        public SpeakerIconType SpeakerIconType { get; set; }

        [Key(3)]
        public int SpeakerIconIndex { get; set; }
    }
}
