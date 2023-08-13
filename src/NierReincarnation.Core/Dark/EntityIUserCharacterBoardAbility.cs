using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_character_board_ability")]
public class EntityIUserCharacterBoardAbility
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int Level { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
