using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllWeaponsCommand : AbstractDbQueryCommand<FetchAllWeaponsCommandArg, List<Weapon>>
{
    public override async Task<List<Weapon>> ExecuteAsync(FetchAllWeaponsCommandArg arg)
    {
        List<Weapon> weapons = new();
        foreach (var darkWeapon in MasterDb.EntityMWeaponTable.All)
        {
            var weapon = await new FetchWeaponCommand().ExecuteAsync(new FetchWeaponCommandArg
            {
                Entity = darkWeapon,
                IncludeStats = arg.IncludeStats,
                IncludeSkills = arg.IncludeSkills,
                IncludeAbilities = arg.IncludeAbilities,
                OnlyEvolved = arg.OnlyEvolved,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (weapon != null)
            {
                weapons.Add(weapon);
            }
        }

        return weapons;
    }
}

public class FetchAllWeaponsCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public bool OnlyEvolved { get; init; } = true;
}
