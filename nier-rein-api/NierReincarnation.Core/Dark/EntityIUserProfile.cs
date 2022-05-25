using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_profile")]
    public class EntityIUserProfile
    {
        [Key(0)] // RVA: 0x1DE722C Offset: 0x1DE722C VA: 0x1DE722C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE726C Offset: 0x1DE726C VA: 0x1DE726C
        public string Name { get; set; }
        [Key(2)] // RVA: 0x1DE7280 Offset: 0x1DE7280 VA: 0x1DE7280
        public long NameUpdateDatetime { get; set; }
        [Key(3)] // RVA: 0x1DE7294 Offset: 0x1DE7294 VA: 0x1DE7294
        public string Message { get; set; }
        [Key(4)] // RVA: 0x1DE72A8 Offset: 0x1DE72A8 VA: 0x1DE72A8
        public long MessageUpdateDatetime { get; set; }
        [Key(5)] // RVA: 0x1DE72BC Offset: 0x1DE72BC VA: 0x1DE72BC
        public int FavoriteCostumeId { get; set; }
        [Key(6)] // RVA: 0x1DE72D0 Offset: 0x1DE72D0 VA: 0x1DE72D0
        public long FavoriteCostumeIdUpdateDatetime { get; set; }
        [Key(7)] // RVA: 0x1DE72E4 Offset: 0x1DE72E4 VA: 0x1DE72E4
        public long LatestVersion { get; set; }
	}
}
