using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportBurdensMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var burden in MasterDb.EntityMFieldEffectGroupTable.All)
        {
            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(burden.AbilityId, burden.DefaultAbilityLevel);
            var abilityNameStr = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId);
            var abilityDescStr = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId);

            Console.WriteLine($"{abilityNameStr} - {abilityDescStr} ({burden.FieldEffectApplyScopeType.ToFormattedStr()})");
        }

        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
