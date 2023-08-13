using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMemoirStoryMenuCommand : AbstractMenuCommand<ExportMemoirStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportMemoirStoryMenuCommand(ExportMemoirStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportMemoirStoryMenuCommandArg arg)
    {
        List<string> memoirNames = new();
        var darkMemoirSeries = MasterDb.EntityMPartsSeriesTable.FindByPartsSeriesId(arg.PartsSeriesId);
        var memoirSeriesName = CalculatorMemory.MemorySeriesName(darkMemoirSeries.PartsSeriesId);

        Console.WriteLine($"__**{memoirSeriesName}**__");
        Console.WriteLine();

        foreach (var darkMemoirGroup in MasterDb.EntityMPartsGroupTable.All.Where(x => x.PartsSeriesId == darkMemoirSeries.PartsSeriesId).OrderBy(x => x.SortOrder))
        {
            foreach (var darkMemoir in MasterDb.EntityMPartsTable.All.Where(x => x.PartsGroupId == darkMemoirGroup.PartsGroupId && x.RarityType == RarityType.S_RARE))
            {
                var memoirName = CalculatorMemory.MemoryName(darkMemoir.PartsId);
                if (memoirNames.Contains(memoirName)) continue;
                memoirNames.Add(memoirName);

                Console.WriteLine($"**{memoirName}**");

                foreach (var line in CalculatorMemory.MemoryDescription(darkMemoir.PartsId).HtmlToDiscordText().Split("\\n"))
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        return Task.CompletedTask;
    }
}

public class ExportMemoirStoryMenuCommandArg
{
    public int PartsSeriesId { get; init; }
}
