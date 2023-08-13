using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_costume_skill_se")]
public class EntityMBattleCostumeSkillSe
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int CostumeSkillReadySeAssetId { get; set; }
}
