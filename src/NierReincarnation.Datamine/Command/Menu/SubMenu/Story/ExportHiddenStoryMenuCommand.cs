using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportHiddenStoryMenuCommand : AbstractMenuCommand<ExportHiddenStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    private record HiddenStoryRecord(string Number, string Title, string Description);

    public ExportHiddenStoryMenuCommand(ExportHiddenStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportHiddenStoryMenuCommandArg arg)
    {
        List<HiddenStoryRecord> texts = new();
        var characterSymbolName = string.Empty;

        foreach (var reportId in arg.ReportIds)
        {
            var darkReport = MasterDb.EntityMReportTable.FindByReportId(reportId);
            characterSymbolName = NierReinExtensions.GetCharacterSymbolName(darkReport.CharacterId);

            texts.Add(new HiddenStoryRecord($"report.library.title.{darkReport.ReportAssetId:D6}".Localize(), $"report.title.{darkReport.ReportAssetId:D6}".Localize(), $"report.description.{darkReport.ReportAssetId:D6}".Localize()));
        }

        Console.WriteLine($"{string.Format(UserInterfaceTextKey.Report.kReportSymbolTitle.Localize(), characterSymbolName)}".ToHeader2());
        Console.WriteLine();
        foreach (var text in texts)
        {
            if (string.IsNullOrEmpty(text.Description)) continue;

            var lines = text.Description.HtmlToDiscordText().Split("\\n");

            Console.WriteLine($"{text.Number} ~ {text.Title}".ToBold());
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        return Task.CompletedTask;
    }
}

public class ExportHiddenStoryMenuCommandArg
{
    public List<int> ReportIds { get; init; }
}
