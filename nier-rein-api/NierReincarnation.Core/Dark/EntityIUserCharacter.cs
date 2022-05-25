using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character")]
    public class EntityIUserCharacter
    {
        [Key(0)] // RVA: 0x1DE7D60 Offset: 0x1DE7D60 VA: 0x1DE7D60
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE7DA0 Offset: 0x1DE7DA0 VA: 0x1DE7DA0
        public int CharacterId { get; set; }
        [Key(2)] // RVA: 0x1DE7DE0 Offset: 0x1DE7DE0 VA: 0x1DE7DE0
        public int Level { get; set; }
        [Key(3)] // RVA: 0x1DE7DF4 Offset: 0x1DE7DF4 VA: 0x1DE7DF4
        public int Exp { get; set; }
        [Key(4)] // RVA: 0x1DE7E08 Offset: 0x1DE7E08 VA: 0x1DE7E08
        public long LatestVersion { get; set; }
	}
}
