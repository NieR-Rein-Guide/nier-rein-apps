using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_type_note")]
    public class EntityIUserDeckTypeNote
    {
        [Key(0)] // RVA: 0x1DE8C70 Offset: 0x1DE8C70 VA: 0x1DE8C70
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE8CB0 Offset: 0x1DE8CB0 VA: 0x1DE8CB0
        public DeckType DeckType { get; set; }
        [Key(2)] // RVA: 0x1DE8CF0 Offset: 0x1DE8CF0 VA: 0x1DE8CF0
        public int MaxDeckPower { get; set; }
        [Key(3)] // RVA: 0x1DE8D04 Offset: 0x1DE8D04 VA: 0x1DE8D04
        public long LatestVersion { get; set; }
	}
}
