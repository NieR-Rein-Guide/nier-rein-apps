using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_bgm_set_group")]
public class EntityMBattleBgmSetGroup
{
    [Key(0)]
    public int BgmSetGroupId { get; set; }

    [Key(1)]
    public int BgmSetGroupIndex { get; set; }

    [Key(2)]
    public int BgmSetId { get; set; }

    [Key(3)]
    public int RandomWeight { get; set; }
}
