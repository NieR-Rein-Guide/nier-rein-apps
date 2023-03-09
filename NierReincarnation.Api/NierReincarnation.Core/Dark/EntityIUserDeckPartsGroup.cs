using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_parts_group")]
    public class EntityIUserDeckPartsGroup
    {
        [Key(0)] // RVA: 0x1DE8AA0 Offset: 0x1DE8AA0 VA: 0x1DE8AA0
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE8AE0 Offset: 0x1DE8AE0 VA: 0x1DE8AE0
        public string UserDeckCharacterUuid { get; set; }
        [Key(2)] // RVA: 0x1DE8B20 Offset: 0x1DE8B20 VA: 0x1DE8B20
        public string UserPartsUuid { get; set; }
        [Key(3)] // RVA: 0x1DE8B60 Offset: 0x1DE8B60 VA: 0x1DE8B60
        public int SortOrder { get; set; }
        [Key(4)] // RVA: 0x1DE8B74 Offset: 0x1DE8B74 VA: 0x1DE8B74
        public long LatestVersion { get; set; }
	}
}
