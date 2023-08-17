using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportRodCharacterStoryMenuCommand : AbstractMenuCommand<ExportRodCharacterStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportRodCharacterStoryMenuCommand(ExportRodCharacterStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportRodCharacterStoryMenuCommandArg arg)
    {
        List<string> texts = new();
        var characterName = string.Empty;
        var counter = 0;

        foreach (var eventQuestChapterId in arg.EventQuestChapterIds)
        {
            var darkEventQuestChapter = MasterDb.EntityMEventQuestChapterTable.FindByEventQuestChapterId(eventQuestChapterId);
            var darkEventQuestSequenceGroup = MasterDb.EntityMEventQuestSequenceGroupTable.FindByEventQuestSequenceGroupIdAndDifficultyType((darkEventQuestChapter.EventQuestSequenceGroupId, DifficultyType.NORMAL));
            var lastQuestId = MasterDb.EntityMEventQuestSequenceTable.All.Where(x => x.EventQuestSequenceId == darkEventQuestSequenceGroup.EventQuestSequenceId).OrderBy(x => x.SortOrder).LastOrDefault().QuestId;

            var characterId = CalculatorQuest.GetChapterCharacterId(darkEventQuestChapter.EventQuestChapterId);
            characterName = CalculatorCharacter.GetCharacterName(characterId);
            texts.Add($"limit.content.story.{lastQuestId:D7}".Localize());
        }

        Console.WriteLine(characterName.ToHeader2());
        Console.WriteLine();
        foreach (var text in texts)
        {
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

        return Task.CompletedTask;
    }
}

public class ExportRodCharacterStoryMenuCommandArg
{
    public List<int> EventQuestChapterIds { get; init; }
}
