using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportExCharacterStoryMenuCommand : AbstractMenuCommand<ExportExCharacterStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportExCharacterStoryMenuCommand(ExportExCharacterStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportExCharacterStoryMenuCommandArg arg)
    {
        var darkEventQuestChapter = MasterDb.EntityMEventQuestChapterTable.FindByEventQuestChapterId(arg.EventQuestChapterId);

        var counter = 0;
        var characterId = CalculatorQuest.GetChapterCharacterId(darkEventQuestChapter.EventQuestChapterId);
        var characterName = CalculatorCharacter.GetCharacterName(characterId);
        var endWeaponId = CalculatorCharacter.GetEndWeaponId(characterId);
        var eventMapNumberUpper = MasterDb.EntityMContentsStoryTable.All.Where(x => x.ConditionValue == endWeaponId).Select(x => x.EventMapNumberUpper).FirstOrDefault();
        var darkContentsStories = MasterDb.EntityMContentsStoryTable.All.Where(x => x.EventMapNumberUpper == eventMapNumberUpper).OrderBy(x => x.EventMapNumberLower);

        Console.WriteLine(characterName.ToHeader2());
        Console.WriteLine();
        foreach (var darkContentsStory in darkContentsStories)
        {
            string text = $"content.story.{darkContentsStory.EventMapNumberUpper:D7}.{darkContentsStory.EventMapNumberLower:D6}".Localize();

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

public class ExportExCharacterStoryMenuCommandArg
{
    public int EventQuestChapterId { get; init; }
}
