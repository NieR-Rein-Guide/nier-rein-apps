using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportEventStoryMenuCommand : AbstractMenuCommand<ExportEventStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportEventStoryMenuCommand(ExportEventStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportEventStoryMenuCommandArg arg)
    {
        var darkEventQuestChapter = MasterDb.EntityMEventQuestChapterTable.FindByEventQuestChapterId(arg.EventQuestChapterId);
        var eventName = string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, darkEventQuestChapter.NameEventQuestTextId).Localize();

        Console.WriteLine(eventName.ToHeader2());
        Console.WriteLine();
        foreach (var darkEventQuestSequenceGroup in MasterDb.EntityMEventQuestSequenceGroupTable.All.Where(x => x.EventQuestSequenceGroupId == darkEventQuestChapter.EventQuestSequenceGroupId))
        {
            var darkEventQuestSequences = MasterDb.EntityMEventQuestSequenceTable.All
                .Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId)
                .OrderBy(x => x.SortOrder)
                .ToList();

            var counter = 0;
            foreach (var darkEventQuestSequence in darkEventQuestSequences)
            {
                string text = $"quest.event.chapter.story.{(int)darkEventQuestChapter.EventQuestType:D2}.{darkEventQuestChapter.SortOrder:D4}.{darkEventQuestSequence.SortOrder:D4}".Localize();

                if (string.IsNullOrEmpty(text)) continue;

                var lines = text.HtmlToDiscordText().Split("\\n");

                Console.WriteLine($"Story {++counter}".ToBold());
                foreach (var line in lines)
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

public class ExportEventStoryMenuCommandArg
{
    public int EventQuestChapterId { get; init; }
}
