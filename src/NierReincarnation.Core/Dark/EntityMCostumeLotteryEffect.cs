using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_lottery_effect")]
public class EntityMCostumeLotteryEffect
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int CostumeLotteryEffectOddsGroupId { get; set; }

    [Key(3)]
    public int CostumeLotteryEffectUnlockMaterialGroupId { get; set; }

    [Key(4)]
    public int CostumeLotteryEffectDrawMaterialGroupId { get; set; }

    [Key(5)]
    public int CostumeLotteryEffectReleaseScheduleId { get; set; }
}
