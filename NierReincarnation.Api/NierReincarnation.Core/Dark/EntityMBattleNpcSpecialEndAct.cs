using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_npc_special_end_act")]
public class EntityMBattleNpcSpecialEndAct
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int WaveNumber { get; set; }

    [Key(2)]
    public long BattleNpcId { get; set; }

    [Key(3)]
    public string BattleNpcDeckCharacterUuid { get; set; }

    [Key(4)]
    public SpecialEndBattleActType SpecialEndBattleActType { get; set; }
}
