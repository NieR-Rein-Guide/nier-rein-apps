using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportQuestsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => false;

    public override Task ExecuteAsync()
    {
        Console.WriteLine(nameof(EntityMQuestTable));
        foreach (var item in CalculatorQuest.GetAllEventQuestChapters()
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.StartDatetime))
        {
            Console.WriteLine($"{item.EventQuestName} ({item.EventQuestType}) {item.ToFormattedDateStr()}");

            foreach (var difficultyType in item.EventQuestChapterDifficultyTypes)
            {
                var quests = CalculatorQuest.GenerateEventQuestData(item.EventQuestChapterId, difficultyType);

                Console.WriteLine($"-{difficultyType.ToFormattedStr()}");

                foreach (var quest in quests)
                {
                    Console.WriteLine($"-- {quest.QuestName} - {quest.AttributeType} ({quest.RecommendPower}) -> {CalculatorPossession.GetItemName(quest.QuestFirstReward)} x{quest.QuestFirstReward.Count}");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
