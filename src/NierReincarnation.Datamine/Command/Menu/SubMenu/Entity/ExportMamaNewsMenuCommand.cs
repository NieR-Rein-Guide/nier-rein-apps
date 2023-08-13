using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMamaNewsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var item in MasterDb.EntityMDokanTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.StartDatetime)
            .ThenBy(x => x.SortOrder))
        {
            var groups = MasterDb.EntityMDokanContentGroupTable.All.Where(x => x.DokanContentGroupId == item.DokanContentGroupId).OrderBy(x => x.ContentIndex);
            var texts = groups.Select(x => MasterDb.EntityMDokanTextTable.FindByDokanTextIdAndLanguageType((x.DokanTextId, LanguageType.EN)));

            Console.WriteLine($"{GetDokanTypeStr(item.DokanType)} {item.ToFormattedDateStr()}");

            foreach (var text in texts)
            {
                Console.WriteLine($"- {text.Text}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }

    private static string GetDokanTypeStr(DokanType type)
    {
        return type switch
        {
            DokanType.APPEAL => "Appeal",
            DokanType.FUNCTION_INTRODUCTION => "Function Introduction",
            _ => "Unknown"
        };
    }
}
