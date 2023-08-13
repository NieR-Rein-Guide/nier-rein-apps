using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_collection_bonus_effect")]
public class EntityMCollectionBonusEffect
{
    [Key(0)]
    public int CollectionBonusEffectId { get; set; }

    [Key(1)]
    public CollectionBonusEffectType CollectionBonusEffectType { get; set; }

    [Key(2)]
    public int Amount00 { get; set; }

    [Key(3)]
    public int Amount01 { get; set; }

    [Key(4)]
    public int Amount02 { get; set; }

    [Key(5)]
    public int Amount03 { get; set; }

    [Key(6)]
    public int Amount04 { get; set; }
}
