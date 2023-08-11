using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_parts_preset")]
public class EntityMBattleNpcPartsPreset
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int BattleNpcPartsPresetNumber { get; set; }

    [Key(2)]
    public string BattleNpcPartsUuid01 { get; set; }

    [Key(3)]
    public string BattleNpcPartsUuid02 { get; set; }

    [Key(4)]
    public string BattleNpcPartsUuid03 { get; set; }

    [Key(5)]
    public string Name { get; set; }

    [Key(6)]
    public int BattleNpcPartsPresetTagNumber { get; set; }
}
