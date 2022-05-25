using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_board_ability")]
    public class EntityIUserCharacterBoardAbility
    {
        [Key(0)] // RVA: 0x1DE7F00 Offset: 0x1DE7F00 VA: 0x1DE7F00
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE7F40 Offset: 0x1DE7F40 VA: 0x1DE7F40
        public int CharacterId { get; set; }
        [Key(2)] // RVA: 0x1DE7F80 Offset: 0x1DE7F80 VA: 0x1DE7F80
        public int AbilityId { get; set; }
        [Key(3)] // RVA: 0x1DE7FC0 Offset: 0x1DE7FC0 VA: 0x1DE7FC0
        public int Level { get; set; }
        [Key(4)] // RVA: 0x1DE7FD4 Offset: 0x1DE7FD4 VA: 0x1DE7FD4
        public long LatestVersion { get; set; }
	}
}
