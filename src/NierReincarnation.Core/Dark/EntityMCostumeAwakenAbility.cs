using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_awaken_ability")]
public class EntityMCostumeAwakenAbility
{
    [Key(0)]
    public int CostumeAwakenAbilityId { get; set; }

    [Key(1)]
    public int AbilityId { get; set; }

    [Key(2)]
    public int AbilityLevel { get; set; }
}
