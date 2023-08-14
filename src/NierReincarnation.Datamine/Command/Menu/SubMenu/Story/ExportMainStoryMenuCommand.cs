using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMainStoryMenuCommand : AbstractMenuCommand<ExportMainStoryMenuCommandArg>
{
    public ExportMainStoryMenuCommand(ExportMainStoryMenuCommandArg arg) : base(arg) { }

    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync(ExportMainStoryMenuCommandArg arg)
    {
        var darkMainQuestChapter = MasterDb.EntityMMainQuestChapterTable.FindByMainQuestChapterId(arg.MainQuestChapterId);
        (string chatperNumber, string chapterTitle) = CalculatorQuest.GetMainQuestChapterText(darkMainQuestChapter.MainQuestRouteId, darkMainQuestChapter.SortOrder);
        var seasonId = CalculatorQuest.GetMainQuestSeasonId(darkMainQuestChapter.MainQuestRouteId);
        var darkMainQuestSequenceGroup = MasterDb.EntityMMainQuestSequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((darkMainQuestChapter.MainQuestSequenceGroupId, DifficultyType.NORMAL));
        var darkMainQuestSequences = MasterDb.EntityMMainQuestSequenceTable.All.Where(x => x.MainQuestSequenceId == darkMainQuestSequenceGroup.MainQuestSequenceId).OrderBy(x => x.SortOrder);

        Console.WriteLine($"__**{chapterTitle}**__");
        Console.WriteLine();
        if (arg.LibraryMainQuestGroupId == null)
        {
            PrintMainStoryChapter(arg.MainQuestChapterId, seasonId);
        }
        else
        {
            PrintLibraryStory(arg.MainQuestChapterId, arg.LibraryMainQuestGroupId.Value, seasonId);
        }

        return Task.CompletedTask;
    }

    private static void PrintMainStoryChapter(int mainQuestChapterId, int seasonId)
    {
        var darkMainQuestChapter = MasterDb.EntityMMainQuestChapterTable.FindByMainQuestChapterId(mainQuestChapterId);
        var darkMainQuestSequenceGroup = MasterDb.EntityMMainQuestSequenceGroupTable.FindByMainQuestSequenceGroupIdAndDifficultyType((darkMainQuestChapter.MainQuestSequenceGroupId, DifficultyType.NORMAL));
        var darkMainQuestSequences = MasterDb.EntityMMainQuestSequenceTable.All.Where(x => x.MainQuestSequenceId == darkMainQuestSequenceGroup.MainQuestSequenceId).OrderBy(x => x.SortOrder);
        var counter = 0;

        foreach (var darkMainQuestSequence in darkMainQuestSequences)
        {
            var darkQuest = MasterDb.EntityMQuestTable.FindByQuestId(darkMainQuestSequence.QuestId);

            if (CalculatorQuest.HasScenario(darkQuest))
            {
                var text = $"story.Main.Quest.{seasonId:D4}.{mainQuestChapterId:D4}.{darkQuest.QuestId:D4}".Localize();

                if (string.IsNullOrEmpty(text)) continue;
                var lines = text.HtmlToDiscordText().Split("\\n");

                Console.WriteLine($"**Story {++counter}**");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    private static void PrintLibraryStory(int mainQuestChapterId, int libraryMainQuestGroupId, int seasonId)
    {
        var counter = 0;
        foreach (var darkLibraryMainQuestStory in MasterDb.EntityMLibraryMainQuestStoryTable.FindByLibraryMainQuestGroupId(libraryMainQuestGroupId))
        {
            var questScene = MasterDb.EntityMQuestSceneTable.FindByQuestSceneId(darkLibraryMainQuestStory.RecollectionSceneId);
            var text = $"story.Main.Quest.{seasonId:D4}.{mainQuestChapterId:D4}.{questScene.QuestId:D4}.{darkLibraryMainQuestStory.TextAssetId}".Localize();

            if (string.IsNullOrEmpty(text)) continue;
            var lines = text.HtmlToDiscordText().Split("\\n");

            Console.WriteLine($"**Story {++counter}**");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}

public class ExportMainStoryMenuCommandArg
{
    public int MainQuestChapterId { get; init; }

    public int? LibraryMainQuestGroupId { get; init; }
}
