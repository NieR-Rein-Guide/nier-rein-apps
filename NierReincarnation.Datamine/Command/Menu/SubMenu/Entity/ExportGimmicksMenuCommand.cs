using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class ExportGimmicksMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override async Task ExecuteAsync()
    {
        List<Gimmick> gimmicks = await new FetchAllGimmicksCommand().ExecuteAsync(new FetchAllGimmicksCommandArg());

        foreach (var chapterGroup in gimmicks.GroupBy(x => x.ChapterId).OrderBy(x => x.Key))
        {
            Console.WriteLine($"**Chapter {chapterGroup.Key}**");

            foreach (var gimmickGroup in chapterGroup.GroupBy(x => x.GimmickType))
            {
                if (CalculatorWorldMap.IsIntervalDropItemType(gimmickGroup.Key))
                {
                    var internalStr = string.Join(",", gimmickGroup.OrderBy(x => x.IntervalValue).Select(x => x.IntervalValue / 60));

                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()} (Every {internalStr} hours, up to {gimmickGroup.Max(x => x.MaxValue)} items)");
                }
                else if (gimmickGroup.Key == GimmickType.CAGE_MEMORY)
                {
                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()} ({gimmickGroup.Count()})");
                }
                else if (gimmickGroup.Key == GimmickType.CAGE_TREASURE_HUNT)
                {
                    var pastGimmicks = gimmickGroup.Where(x => x.EndDateTimeOffset < DateTimeOffset.Now);

                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()} ({gimmickGroup.Count()})");
                    Console.WriteLine($"- {pastGimmicks.Count()} birds in the past");

                    foreach (var gimmick in gimmickGroup.Except(pastGimmicks).OrderBy(x => x.StartDateTimeOffset))
                    {
                        Console.WriteLine($"- {gimmick.StartDateTimeOffset.Value.ToFormattedDate()} ~ {gimmick.EndDateTimeOffset.Value.ToFormattedDate()}");
                    }
                }
                else if (gimmickGroup.Key == GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT)
                {
                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()} ({gimmickGroup.Count()})");
                }
                else if (gimmickGroup.Key == GimmickType.MAP_ONLY_HIDE_OBELISK)
                {
                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()} ({gimmickGroup.Count()})");
                }
                else if (gimmickGroup.Key == GimmickType.REPORT)
                {
                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()}");
                    foreach (var gimmick in gimmickGroup.OrderBy(x => x.ProgressStartDateTimeOffset))
                    {
                        Console.WriteLine($"- {gimmick.ProgressStartDateTimeOffset.ToFormattedDate(true)} - {gimmick.Reward.Name} -> {string.Join(" & ", gimmick.ClearConditions)}");
                    }
                }
                else
                {
                    Console.WriteLine($"{gimmickGroup.Key.ToFormattedStr()}");
                    foreach (var gimmick in gimmickGroup.OrderBy(x => x.StartDateTimeOffset))
                    {
                        Console.WriteLine($"- {gimmick.StartDateTimeOffset.Value.ToFormattedDate(true)} ~ {gimmick.EndDateTimeOffset.Value.ToFormattedDate(true)}");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
