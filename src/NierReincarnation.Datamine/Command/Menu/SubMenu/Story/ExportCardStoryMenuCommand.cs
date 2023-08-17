using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCardStoryMenuCommand : AbstractMenuCommand<ExportCardStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCardStoryMenuCommand(ExportCardStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCardStoryMenuCommandArg arg)
    {
        var darkWebviewMission = MasterDb.EntityMWebviewMissionTable.All.FirstOrDefault(x => x.WebviewMissionId == arg.WebviewMissionId);
        var darkWebviewMissionTitleText = MasterDb.EntityMWebviewMissionTitleTextTable.FindByWebviewMissionTitleTextIdAndLanguageType((darkWebviewMission.TitleTextId, LanguageType.EN));
        var darkWebviewPanelMissions = MasterDb.EntityMWebviewPanelMissionTable.All.Where(x => x.WebviewPanelMissionId == darkWebviewMission.WebviewMissionTargetId).OrderBy(x => x.Page);
        var counter = 0;

        Console.WriteLine(darkWebviewMissionTitleText.Text.ToHeader2());
        Console.WriteLine();
        foreach (var darkWebviewPanelMission in darkWebviewPanelMissions)
        {
            var darkWevbiewPanelMissionPage = MasterDb.EntityMWebviewPanelMissionPageTable.FindByWebviewPanelMissionPageId(darkWebviewPanelMission.WebviewPanelMissionPageId);
            var darkWevbiewPanelMissionCompleteFlavorText = MasterDb.EntityMWebviewPanelMissionCompleteFlavorTextTable
                .FindByWebviewPanelMissionCompleteFlavorTextIdAndLanguageType((darkWevbiewPanelMissionPage.WebviewPanelMissionCompleteFlavorTextId, LanguageType.EN));

            string text = darkWevbiewPanelMissionCompleteFlavorText.CompleteFlavorText;
            if (string.IsNullOrEmpty(text)) continue;

            var lines = text.HtmlToDiscordText().Split("\\n");

            Console.WriteLine($"Story {++counter}".ToBold());
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        return Task.CompletedTask;
    }
}

public class ExportCardStoryMenuCommandArg
{
    public int WebviewMissionId { get; init; }
}
