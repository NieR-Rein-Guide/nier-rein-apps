using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_rebirth")]
    public class EntityIUserCharacterRebirth
    {
        [Key(0)] // RVA: 0x226DC30 Offset: 0x226DC30 VA: 0x226DC30
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x226DC70 Offset: 0x226DC70 VA: 0x226DC70
        public int CharacterId { get; set; }
        [Key(2)] // RVA: 0x226DCB0 Offset: 0x226DCB0 VA: 0x226DCB0
        public int RebirthCount { get; set; }
        [Key(3)] // RVA: 0x226DCC4 Offset: 0x226DCC4 VA: 0x226DCC4
        public long LatestVersion { get; set; }
    }
}
