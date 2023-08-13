using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchWeaponCommand : AbstractDbQueryCommand<FetchWeaponCommandArg, Weapon>
{
    public override async Task<Weapon> ExecuteAsync(FetchWeaponCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkWeapon = arg.Entity ?? MasterDb.EntityMWeaponTable.FindByWeaponId(arg.EntityId);
        if (darkWeapon == null) return null;

        var evolutionGroup = MasterDb.EntityMWeaponEvolutionGroupTable.All.FirstOrDefault(x => x.WeaponId == darkWeapon.WeaponId);

        if (evolutionGroup == null) return null;
        if (arg.OnlyEvolved && evolutionGroup.EvolutionOrder == 1) return null;

        var baseWeapon = evolutionGroup.EvolutionOrder == 1 ? darkWeapon : GetBaseDarkWeaponByEvolutionGroup(evolutionGroup.WeaponEvolutionGroupId);

        if (baseWeapon == null) return null;

        var baseWeaponCatalog = MasterDb.EntityMCatalogWeaponTable.FindByWeaponId(baseWeapon.WeaponId);
        var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(baseWeaponCatalog?.CatalogTermId ?? 0);

        if (termCatalog != null)
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
        }

        var darkWeaponAwaken = MasterDb.EntityMWeaponAwakenTable.FindByWeaponId(darkWeapon.WeaponId);

        return new Weapon
        {
            Name = CalculatorWeapon.WeaponName(darkWeapon.WeaponId),
            AssetId = CalculatorWeapon.ActorAssetId(darkWeapon.WeaponId).StringId,
            Level = CalculatorWeapon.GetWeaponMaxLevel(darkWeapon, Config.GetWeaponLimitBreakAvailableCount(), darkWeaponAwaken?.LevelLimitUp ?? 0),
            AttributeType = darkWeapon.AttributeType,
            RarityType = darkWeapon.RarityType,
            WeaponType = darkWeapon.WeaponType,
            ReleaseDateTimeOffset = termCatalog != null ? CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime) : DateTimeOffset.MaxValue,
            Stats = await GetWeaponStatsAsync(arg, darkWeapon),
            Skills = await GetWeaponSkillsAsync(arg, darkWeapon),
            Abilities = await GetWeaponAbilitiesAsync(arg, darkWeapon)
        };
    }

    public EntityMWeapon GetBaseDarkWeaponByEvolutionGroup(int weaponEvolutionGroupId)
    {
        var evolutionGroup = MasterDb.EntityMWeaponEvolutionGroupTable.All.FirstOrDefault(x => x.WeaponEvolutionGroupId == weaponEvolutionGroupId && x.EvolutionOrder == 1);

        if (evolutionGroup == null) return null;

        return MasterDb.EntityMWeaponTable.FindByWeaponId(evolutionGroup.WeaponId);
    }

    private static async Task<WeaponStats> GetWeaponStatsAsync(FetchWeaponCommandArg arg, EntityMWeapon darkWeapon)
    {
        if (!arg.IncludeStats) return null;

        return await new FetchWeaponStatsCommand().ExecuteAsync(new FetchWeaponStatsCommandArg
        {
            Entity = darkWeapon
        });
    }

    private static async Task<List<WeaponSkill>> GetWeaponSkillsAsync(FetchWeaponCommandArg arg, EntityMWeapon darkWeapon)
    {
        if (!arg.IncludeSkills) return null;

        return await new FetchWeaponSkillsCommand().ExecuteAsync(new FetchWeaponSkillsCommandArg
        {
            Entity = darkWeapon
        });
    }

    private static async Task<List<WeaponAbility>> GetWeaponAbilitiesAsync(FetchWeaponCommandArg arg, EntityMWeapon darkWeapon)
    {
        if (!arg.IncludeAbilities) return null;

        return await new FetchWeaponAbilitiesCommand().ExecuteAsync(new FetchWeaponAbilitiesCommandArg
        {
            Entity = darkWeapon,
            IncludeBarrierAbility = true
        });
    }
}

public class FetchWeaponCommandArg : AbstractEntityCommandWithDatesArg<EntityMWeapon>
{
    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public bool OnlyEvolved { get; init; } = true;
}
