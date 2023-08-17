using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCostumeKarmaSlotsCommand : AbstractDbQueryCommand<FetchCostumeKarmaSlotsCommandArg, List<CostumeKarmaSlot>>
{
    public override Task<List<CostumeKarmaSlot>> ExecuteAsync(FetchCostumeKarmaSlotsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<CostumeKarmaSlot>>(null);

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return Task.FromResult<List<CostumeKarmaSlot>>(null);

        List<CostumeKarmaSlot> costumeKarmaSlots = new();

        foreach (var darkCostumeKarmaSlot in MasterDb.EntityMCostumeLotteryEffectTable.All.Where(x => x.CostumeId == darkCostume.CostumeId).OrderBy(x => x.SlotNumber))
        {
            if (!arg.KarmaSlots.Contains(darkCostumeKarmaSlot.SlotNumber)) continue;

            if (!MasterDb.EntityMCostumeLotteryEffectReleaseScheduleTable.TryFindByCostumeLotteryEffectReleaseScheduleId(
                darkCostumeKarmaSlot.CostumeLotteryEffectReleaseScheduleId, out var darkCostumeKarmaReleaseSchedule)) continue;

            var darkCostumeKarmaSlotOdds = MasterDb.EntityMCostumeLotteryEffectOddsGroupTable
                .FindByCostumeLotteryEffectOddsGroupId(darkCostumeKarmaSlot.CostumeLotteryEffectOddsGroupId);

            List<CostumeKarmaItem> costumeKarmaItems = new();
            foreach (var darkCostumeKarmaSlotOdd in darkCostumeKarmaSlotOdds.OrderBy(x => x.OddsNumber))
            {
                if (darkCostumeKarmaSlotOdd.RarityType != RarityType.SS_RARE) continue;

                    if (darkCostumeKarmaSlotOdd.CostumeLotteryEffectType == CostumeLotteryEffectType.ABILITY)
                {
                    var darkCostumeKarmaSlotAbility = MasterDb.EntityMCostumeLotteryEffectTargetAbilityTable
                        .FindByCostumeLotteryEffectTargetAbilityId(darkCostumeKarmaSlotOdd.CostumeLotteryEffectTargetId);

                    var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkCostumeKarmaSlotAbility.AbilityId, darkCostumeKarmaSlotAbility.AbilityLevel);

                    costumeKarmaItems.Add(new CostumeKarmaAbility
                    {
                        RarityType = darkCostumeKarmaSlotOdd.RarityType,
                        Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                        Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId)
                    });
                }
                else if (darkCostumeKarmaSlotOdd.CostumeLotteryEffectType == CostumeLotteryEffectType.STATUS_UP)
                {
                    var darkCostumeKarmaSlotStatusUps = MasterDb.EntityMCostumeLotteryEffectTargetStatusUpTable
                        .FindByCostumeLotteryEffectTargetStatusUpId(darkCostumeKarmaSlotOdd.CostumeLotteryEffectTargetId);

                    CostumeKarmaStats costumeKarmaStats = new()
                    {
                        RarityType = darkCostumeKarmaSlotOdd.RarityType
                    };
                    foreach (var darkCostumeKarmaSlotStatusUp in darkCostumeKarmaSlotStatusUps)
                    {
                        if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.EVASION_RATIO)
                        {
                            costumeKarmaStats.EvasionRate += darkCostumeKarmaSlotStatusUp.EffectValue;
                        }
                        else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.CRITICAL_RATIO)
                        {
                            costumeKarmaStats.CriticalRate += darkCostumeKarmaSlotStatusUp.EffectValue;
                        }
                        else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.CRITICAL_ATTACK)
                        {
                            costumeKarmaStats.CriticalDamage += darkCostumeKarmaSlotStatusUp.EffectValue;
                        }
                        else
                        {
                            if (darkCostumeKarmaSlotStatusUp.StatusCalculationType == StatusCalculationType.ADD)
                            {
                                if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.AGILITY)
                                {
                                    costumeKarmaStats.AgilityFlat += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.ATTACK)
                                {
                                    costumeKarmaStats.AttackFlat += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.HP)
                                {
                                    costumeKarmaStats.HpFlat += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.VITALITY)
                                {
                                    costumeKarmaStats.DefenseFlat += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                            }
                            else if (darkCostumeKarmaSlotStatusUp.StatusCalculationType == StatusCalculationType.MULTIPLY)
                            {
                                if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.AGILITY)
                                {
                                    costumeKarmaStats.AgilityPercent += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.ATTACK)
                                {
                                    costumeKarmaStats.AttackPercent += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.HP)
                                {
                                    costumeKarmaStats.HpPercent += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                                else if (darkCostumeKarmaSlotStatusUp.StatusKindType == StatusKindType.VITALITY)
                                {
                                    costumeKarmaStats.DefensePercent += darkCostumeKarmaSlotStatusUp.EffectValue;
                                }
                            }
                        }
                    }

                    costumeKarmaItems.Add(costumeKarmaStats);
                }
            }

            costumeKarmaSlots.Add(new CostumeKarmaSlot
            {
                ReleaseDateTimeOffset = CalculatorDateTime.FromUnixTime(darkCostumeKarmaReleaseSchedule.ReleaseDatetime),
                SlotOrder = darkCostumeKarmaSlot.SlotNumber,
                Items = costumeKarmaItems
            });
        }

        return Task.FromResult(costumeKarmaSlots);
    }
}

public class FetchCostumeKarmaSlotsCommandArg : AbstractEntityCommandArg<EntityMCostume>
{
    public int[] KarmaSlots { get; init; } = Array.Empty<int>();

    public override bool IsValid()
    {
        return base.IsValid() && KarmaSlots.All(x => x >= 0 && x <= 3);
    }
}
