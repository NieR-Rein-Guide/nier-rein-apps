using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSpeaker))]
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
