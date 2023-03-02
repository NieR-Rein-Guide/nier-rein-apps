using CommandLine;
using CommandLine.Text;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.Cli
{
    internal class Options
    {
        [Option('u', "username", HelpText = "Set the username to log in with")]
        public string Username { get; set; }

        [Option('p', "password", HelpText = "Set the password to log in with")]
        public string Password { get; set; }

        [Option('m', "mode", Required = true, HelpText = "Set the mode to execute\n  1: future quests\n  2: current quests\n  3: decks\n  4: notices\n  5: download all assets\n  6: download all sound assets")]
        public int Mode { get; set; }
    }

    public enum Mode
    {
        FutureQuests = 1,
        CurrentQuests,
        Decks,
        Notices,
        AssetDownload,
        SoundAssetDownload
    }

    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var parser = new Parser(parserSettings => parserSettings.AutoHelp = true);

            var parsedResult = parser.ParseArguments<Options>(args);

            await parsedResult
                .WithNotParsed(errors => DisplayHelp(parsedResult, errors))
                .WithParsedAsync(Execute);
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> _)
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
            // Setup necessary systems
            switch ((Mode)o.Mode)
            {
                case Mode.FutureQuests:
                case Mode.CurrentQuests:
                case Mode.Decks:
                    await NierReincarnation.PrepareCommandLine(o.Username, o.Password);
                    await NierReincarnation.LoadLocalizations(Language.English);
                    break;
            }

            // Execute mode
            switch ((Mode)o.Mode)
            {
                case Mode.FutureQuests:
                    PrintFutureQuests();
                    break;

                case Mode.CurrentQuests:
                    PrintCurrentQuests();
                    break;

                case Mode.Decks:
                    PrintDecks();
                    break;

                case Mode.Notices:
                    await PrintNotices();
                    break;

                case Mode.AssetDownload:
                    await NierReincarnation.Assets.DownloadAllAssets();
                    await NierReincarnation.Assets.DownloadAllResources();
                    break;

                case Mode.SoundAssetDownload:
                    await NierReincarnation.Assets.DownloadAssets(s => s.name.StartsWith("audio"));
                    break;
            }
        }

        private static void PrintCurrentQuests()
        {
            Console.WriteLine("Current events:");
            foreach (var chapter in CalculatorQuest.GetAllEventQuestChapters())
            {
                if (!chapter.IsCurrent())
                    continue;

                Console.WriteLine($"  {chapter.EventQuestName}");
                Console.WriteLine($"  {chapter.StartDate} - {chapter.EndDate}");

                foreach (var diff in chapter.EventQuestChapterDifficultyTypes)
                {
                    Console.WriteLine($"  Difficulty: {diff}");

                    foreach (var dq in CalculatorQuest.GenerateEventQuestData(chapter.EventQuestChapterId, diff))
                        Console.WriteLine($"    {(dq.IsLock ? "[Locked] " : "")}{dq.QuestName}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintFutureQuests()
        {
            Console.WriteLine("Future events:");
            foreach (var chapter in CalculatorQuest.GetAllEventQuestChapters())
            {
                if (!chapter.IsFuture())
                    continue;

                Console.WriteLine($"  {chapter.EventQuestName}");
                Console.WriteLine($"  {chapter.StartDate} - {chapter.EndDate}");

                foreach (var diff in chapter.EventQuestChapterDifficultyTypes)
                {
                    Console.WriteLine($"  Difficulty: {diff}");

                    foreach (var dq in CalculatorQuest.GenerateEventQuestData(chapter.EventQuestChapterId, diff))
                        Console.WriteLine($"    {(dq.IsLock ? "[Locked] " : "")}{dq.QuestName}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintDecks()
        {
            Console.WriteLine("Quest decks:");
            foreach (var ql in CalculatorDeck.EnumerateDeckDataList(CalculatorStateUser.GetUserId(), DeckType.QUEST))
            {
                var deckName = ql.Name?.Length == 0 ? "Quest " + ql.UserDeckNumber : ql.Name;

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
                        {
                            if (mem != null)
                            {
                                Console.WriteLine($"      Memory:    {mem.Name} Lvl{mem.Level} [{mem.SeriesName}]");
                            }
                        }
                    }
                }
            }
        }

        private static async Task PrintNotices()
        {
            // Print notices
            Console.WriteLine("Latest 10 notices:");
            Console.WriteLine();

            await foreach (var n in NierReincarnation.Notifications.GetNotifications(1, 20))
            {
                Console.WriteLine($"[{n.informationType}] {n.title}");
                if (!string.IsNullOrEmpty(n.thumbnailImagePath))
                    Console.WriteLine($"https://web.app.nierreincarnation.com{n.thumbnailImagePath}");
                Console.WriteLine();
            }
        }
    }
}
