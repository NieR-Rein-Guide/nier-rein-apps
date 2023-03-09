using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;
using System.Text;

namespace NierReincarnation.Datamine.Command;

public class ExportMemoirsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override async Task ExecuteAsync()
    {
        StringBuilder sb = new();

        BuildHeaders(sb);

        var userMemoirs = await new FetchAllUserMemoirsCommand().ExecuteAsync(new FetchAllUserMemoirsCommandArg
        {
            MinRarityType = RarityType.S_RARE,
            //MinRarityType = RarityType.NORMAL,
            OnlyMaxLevel = true
        });

        foreach (var userMemoir in userMemoirs)
        {
            BuildLine(sb, userMemoir);
        }

        string filePath = Path.Combine(Constants.DataPath, "memoirs.csv");
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        await File.WriteAllTextAsync(filePath, sb.ToString());
    }

    private static void BuildHeaders(StringBuilder sb)
    {
        sb.Append("Set")
            .Append(',')
            .Append("Name")
            .Append(',')
            .Append("ATK")
            .Append(',')
            .Append("ATK %")
            .Append(',')
            .Append("HP")
            .Append(',')
            .Append("HP %")
            .Append(',')
            .Append("DEF")
            .Append(',')
            .Append("DEF %")
            .Append(',')
            .Append("AGI")
            .Append(',')
            .Append("CRATE")
            .Append(',')
            .Append("CDMG")
            .Append(',')
            .AppendLine("Date");
    }

    private static void BuildLine(StringBuilder sb, UserMemoir userMemoir)
    {
        sb.Append(userMemoir.LargeSet)
            .Append(',')
            .Append(userMemoir.Name)
            .Append(',')
            .Append(userMemoir.AttackFlat)
            .Append(',')
            .Append(userMemoir.AttackPercent)
            .Append(',')
            .Append(userMemoir.HpFlat)
            .Append(',')
            .Append(userMemoir.HpPercent)
            .Append(',')
            .Append(userMemoir.DefenseFlat)
            .Append(',')
            .Append(userMemoir.DefencePercent)
            .Append(',')
            .Append(userMemoir.Agility)
            .Append(',')
            .Append(userMemoir.CriticalRate)
            .Append(',')
            .Append(userMemoir.CriticalDamage)
            .Append(',')
            .AppendLine(userMemoir.AcquisitionDateTimeOffset.ToLocalTime().ToString("s"));
    }
}
