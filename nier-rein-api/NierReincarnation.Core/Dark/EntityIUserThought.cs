using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_thought")]
    public class EntityIUserThought
    {
        [Key(0)] // RVA: 0x1EAE344 Offset: 0x1EAE344 VA: 0x1EAE344
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EAE384 Offset: 0x1EAE384 VA: 0x1EAE384
        public string UserThoughtUuid { get; set; }
        [Key(2)] // RVA: 0x1EAE3C4 Offset: 0x1EAE3C4 VA: 0x1EAE3C4
        public int ThoughtId { get; set; }
        [Key(3)] // RVA: 0x1EAE3D8 Offset: 0x1EAE3D8 VA: 0x1EAE3D8
        public long AcquisitionDatetime { get; set; }
        [Key(4)] // RVA: 0x1EAE3EC Offset: 0x1EAE3EC VA: 0x1EAE3EC
        public long LatestVersion { get; set; }
	}
}
