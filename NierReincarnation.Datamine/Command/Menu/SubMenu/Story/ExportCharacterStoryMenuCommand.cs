using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCharacterStoryMenuCommand : AbstractMenuCommand<ExportCharacterStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCharacterStoryMenuCommand(ExportCharacterStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCharacterStoryMenuCommandArg arg)
    {
        var darkEventQuestChapter = MasterDb.EntityMEventQuestChapterTable.FindByEventQuestChapterId(arg.EventQuestChapterId);

        foreach (var darkEventQuestSequenceGroup in MasterDb.EntityMEventQuestSequenceGroupTable.All.Where(x => x.EventQuestSequenceGroupId == darkEventQuestChapter.EventQuestSequenceGroupId))
        {
            var darkEventQuestSequences = MasterDb.EntityMEventQuestSequenceTable.All
                .Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId)
                .OrderBy(x => x.SortOrder)
                .ToList();

            var counter = 0;
            var characterName = CalculatorCharacter.GetCharacterName(CalculatorQuest.GetChapterCharacterId(darkEventQuestChapter.EventQuestChapterId));

            Console.WriteLine($"__**{characterName}**__");
            Console.WriteLine();
            foreach (var darkEventQuestSequence in darkEventQuestSequences)
            {
                string text = $"quest.event.chapter.story.{(int)darkEventQuestChapter.EventQuestType:D2}.{darkEventQuestChapter.SortOrder:D4}.{darkEventQuestSequence.SortOrder:D4}".Localize();

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

        return Task.CompletedTask;
    }
}

public class ExportCharacterStoryMenuCommandArg
{
    public int EventQuestChapterId { get; init; }
}
