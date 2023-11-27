using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleCostumeSkillFireAct))]
public class EntityMBattleCostumeSkillFireAct
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int BattleSkillFireActId { get; set; }
}
