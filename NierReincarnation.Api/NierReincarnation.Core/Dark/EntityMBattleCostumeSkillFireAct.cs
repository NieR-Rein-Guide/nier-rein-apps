using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_costume_skill_fire_act")]
public class EntityMBattleCostumeSkillFireAct
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int BattleSkillFireActId { get; set; }
}
