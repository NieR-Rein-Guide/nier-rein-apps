using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Events;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Localizations;

namespace nier_rein_cli
{
    class Options
    {
        [Option('u', "username", Required = true, HelpText = "Set the username to log in with")]
        public string Username { get; set; }

        [Option('p', "password", Required = true, HelpText = "Set the password to log in with")]
        public string Password { get; set; }

        [Option('m', "mode", Required = true, HelpText = "Set the mode to execute\n  1: future quests\n  2: current quests\n  3: decks\n  4: notices\n  5: download all assets\n  [EXPERIMENTAL]99: Retreat farm Rion Easy")]
        public int Mode { get; set; }
    }

    public enum Mode
    {
        FutureQuests = 1,
        CurrentQuests,
        Decks,
        Notices,
        AssetDownload,

        SoundAssetDownload = 98,
        RetreatExperiment = 99
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new Parser(parserSettings => parserSettings.AutoHelp = true);

            var parsedResult = parser.ParseArguments<Options>(args);

            await parsedResult
                .WithNotParsed(errors => DisplayHelp(parsedResult, errors))
                .WithParsedAsync(Execute);
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errors)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);

            Console.WriteLine(helpText);
        }

        private static async Task Execute(Options o)
        {
            await NierReincarnation.NierReincarnation.PrepareCommandLine(o.Username, o.Password);
            await NierReincarnation.NierReincarnation.LoadLocalizations(Language.En);

            var rein = NierReincarnation.NierReincarnation.GetContexts();

            switch ((Mode)o.Mode)
            {
                case Mode.FutureQuests:
                    PrintQuests(rein, false);
                    break;

                case Mode.CurrentQuests:
                    PrintQuests(rein, true);
                    break;

                case Mode.Decks:
                    PrintDecks(rein);
                    break;

                case Mode.Notices:
                    await PrintNotices(rein);
                    break;

                case Mode.AssetDownload:
                    await rein.Assets.DownloadAllAssets();
                    await rein.Assets.DownloadAllResources();
                    break;

                case Mode.SoundAssetDownload:
                    await rein.Assets.DownloadAssets(s => s.name.StartsWith("audio"));
                    break;

                case Mode.RetreatExperiment:
                    Console.Write("Retire before purple drop? [y/n] ");
                    var quitPurple = Console.ReadLine();

                    await RetreatFarm(rein, quitPurple == "y");
                    break;

                default:
                    await StartEventQuest(rein);
                    return;
            }
        }

        private static async Task RetreatFarm(NierReinContexts rein, bool quitPurple)
        {
            var deck = rein.Decks.GetQuestDecks().ElementAt(0);

            var endEvent = rein.Quests.GetEndEventChapters().Skip(3).FirstOrDefault();
            var endQuests = rein.Quests.GetEventQuests(endEvent.EventQuestChapterId, DifficultyType.NORMAL);
            var endEasyDaily = endQuests[0];

            rein.Battles.BattleStarted += (sender, args) =>
            {
                args.ShouldQuitBattle = !args.RewardCategories.Contains(RewardCategory.SS_RARE);
                args.ForceShutdown = quitPurple && !args.ShouldQuitBattle;
            };
            rein.Battles.BattleFinished += (sender, args) => PrintRewards(args);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var repeats = 0;
            while (true)
            {
                var battleResult = await rein.Battles.ExecuteEventQuest(endEvent.EventQuestChapterId, endEasyDaily, deck);

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    Console.WriteLine("\r\nUser is out of stamina.");
                    return;
                }

                if (battleResult.Status == BattleStatus.ForceShutdown)
                    Console.WriteLine("\r\nShutdown application after encountering purple drop.");

                if (battleResult.Status != BattleStatus.Retire)
                    break;

                repeats++;
                Console.Write($"\rRetreated {repeats} rounds in {stopwatch.Elapsed} with {repeats * endEasyDaily.Quest.EntityQuest.Stamina} stamina used.");
            }

            stopwatch.Stop();
        }

        private static async Task StartEventQuest(NierReinContexts rein)
        {
            var deck = rein.Decks.GetQuestDecks().ElementAt(0);

            rein.Battles.BattleFinished += (sender, args) => PrintRewards(args);

            var chapters = rein.Quests.GetEventChapters().Where(x => x.IsCurrent());
            foreach (var chapter in chapters)
            {
                var diffs = chapter.EventQuestChapterDifficultyTypes.Select(y => (y, rein.Quests.GetEventQuests(chapter.EventQuestChapterId, y)));
                foreach (var diff in diffs)
                {
                    foreach (var quest in diff.Item2)
                    {
                        Console.WriteLine($"{diff.y} {quest.QuestName}");
                        await rein.Battles.ExecuteEventQuest(chapter.EventQuestChapterId, quest, deck);
                    }
                }
            }
        }

        private static void PrintRewards(FinishBattleEventArgs args)
        {
            if (args.Rewards.DropRewards.Any())
                Console.WriteLine($"Rewards: {string.Join(Environment.NewLine, args.Rewards.DropRewards.Select(x => $"{x.RewardCategory} {x.PossessionName} x{x.Count}"))}");
        }

        private static void PrintQuests(NierReinContexts rein, bool printCurrent)
        {
            if (printCurrent)
                PrintCurrentQuests(rein);
            else
                PrintFutureQuests(rein);
        }

        private static void PrintCurrentQuests(NierReinContexts rein)
        {
            Console.WriteLine("Current events:");
            foreach (var chapter in rein.Quests.GetEventChapters())
            {
                if (!chapter.IsCurrent())
                    continue;

                Console.WriteLine($"  {chapter.EventQuestName}");
                Console.WriteLine($"  {chapter.StartDate} - {chapter.EndDate}");

                foreach (var diff in chapter.EventQuestChapterDifficultyTypes)
                {
                    Console.WriteLine($"  Difficulty: {diff}");

                    foreach (var dq in rein.Quests.GetEventQuests(chapter.EventQuestChapterId, diff))
                        Console.WriteLine($"    {(dq.IsLock ? "[Locked] " : "")}{dq.QuestName}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintFutureQuests(NierReinContexts rein)
        {
            Console.WriteLine("Future events:");
            foreach (var chapter in rein.Quests.GetEventChapters())
            {
                if (!chapter.IsFuture())
                    continue;

                Console.WriteLine($"  {chapter.EventQuestName}");
                Console.WriteLine($"  {chapter.StartDate} - {chapter.EndDate}");

                foreach (var diff in chapter.EventQuestChapterDifficultyTypes)
                {
                    Console.WriteLine($"  Difficulty: {diff}");

                    foreach (var dq in rein.Quests.GetEventQuests(chapter.EventQuestChapterId, diff))
                        Console.WriteLine($"    {(dq.IsLock ? "[Locked] " : "")}{dq.QuestName}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintDecks(NierReinContexts rein)
        {
            Console.WriteLine("Quest decks:");
            foreach (var ql in rein.Decks.GetQuestDecks())
            {
                var deckName = ql.Name == string.Empty ? "Quest " + ql.UserDeckNumber : ql.Name;

                Console.WriteLine($"  {deckName} - Force: {ql.Power}");
                for (var ci = 0; ci < ql.UserDeckActors.Length; ci++)
                {
                    var cs = ql.UserDeckActors[ci];
                    if (cs == null)
                        continue;

                    Console.WriteLine($"  Character {ci + 1} Hp{cs.StatusValue.Hp} Atk{cs.StatusValue.Attack} Def{cs.StatusValue.Vitality} Agi{cs.StatusValue.Agility}:");
                    Console.WriteLine($"    Costume: {cs.Costume.Name} Lvl{cs.Costume.CostumeStatus.Level}/{cs.Costume.MaxLevel} Hp{cs.Costume.Hp} Atk{cs.Costume.Attack} Def{cs.Costume.Vitality} Agi{cs.Costume.Agility}");
                    foreach (var ca in cs.Costume.CostumeAbilities)
                        Console.WriteLine($"      {ca.AbilityName} {ca.AbilityLevel}/{ca.AbilityMaxLevel}{(ca.IsLocked ? " [Locked]" : "")}");

                    Console.WriteLine($"    Main Weapon: {cs.MainWeapon.Name} Lvl{cs.MainWeapon.WeaponStatus.Level} Hp{cs.MainWeapon.Hp} Atk{cs.MainWeapon.Attack} Def{cs.MainWeapon.Vitality}");
                    foreach (var ability in cs.MainWeapon.Abilities)
                        Console.WriteLine($"      {ability.AbilityName} {ability.AbilityLevel}/{ability.AbilityMaxLevel}");


                    if (cs.SubWeapon01 != null)
                    {
                        Console.WriteLine($"    Sub Weapon:  {cs.SubWeapon01.Name} Lvl{cs.SubWeapon01.WeaponStatus.Level} Hp{cs.SubWeapon01.StatusValue.Hp} Atk{cs.SubWeapon01.StatusValue.Attack} Def{cs.SubWeapon01.StatusValue.Vitality}");
                        foreach (var ability in cs.SubWeapon01.Abilities)
                            Console.WriteLine($"      {ability.AbilityName}");
                    }

                    if (cs.SubWeapon02 != null)
                    {
                        Console.WriteLine($"    Sub Weapon:  {cs.SubWeapon02.Name} Lvl{cs.SubWeapon02.WeaponStatus.Level} Hp{cs.SubWeapon02.StatusValue.Hp} Atk{cs.SubWeapon02.StatusValue.Attack} Def{cs.SubWeapon02.StatusValue.Vitality}");
                        foreach (var ability in cs.SubWeapon02.Abilities)
                            Console.WriteLine($"      {ability.AbilityName}");
                    }

                    if (cs.Companion != null)
                        Console.WriteLine($"    Companion:   {cs.Companion.Name} Lvl{cs.Companion.CompanionStatus.Level}/{cs.Companion.MaxLevel}");

                    if (cs.Memories.Length > 0)
                    {
                        Console.WriteLine("    Memories:");
                        foreach (var mem in cs.Memories)
                            if (mem != null)
                                Console.WriteLine($"      Memory:    {mem.Name} Lvl{mem.Level} [{mem.SeriesName}]");
                    }
                }
            }
        }

        private static async Task PrintNotices(NierReinContexts rein)
        {
            // Print notices
            Console.WriteLine("Latest 10 notices:");
            Console.WriteLine();

            await foreach (var n in rein.Notifications.GetNotifications())
            {
                Console.WriteLine($"[{n.informationType}] {n.title}");
                if (!string.IsNullOrEmpty(n.thumbnailImagePath))
                    Console.WriteLine($"https://web.app.nierreincarnation.com{n.thumbnailImagePath}");
                Console.WriteLine();
            }
        }
    }
}
