using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Datamine.Extension;
using System.Text.RegularExpressions;

namespace NierReincarnation.Datamine.Command;

public class ExportUnreleasedCostumesMenuCommand : AbstractMenuCommand
{
    private readonly string Pattern = "ch[0-9]{6}";

    private static DataManager DataManager => OctoManager.DataManager;

    public override Task ExecuteAsync()
    {
        Console.WriteLine();
        Dictionary<string, List<string>> unreleasedCostumes = [];
        Dictionary<string, string> currentCharacters = GetCurrentCharacters();
        Dictionary<string, string> currentCostumes = GetCurrentCostumes();

        foreach (string asset in DataManager.GetAllAssetBundleNames())
        {
            var match = Regex.Match(asset, Pattern);

            if (match.Success)
            {
                string matchCostumeId = match.Groups[0].Value;

                if (matchCostumeId.Equals("ch000000")) continue;
                if (matchCostumeId.EndsWith("050")) continue;
                if (currentCostumes.ContainsKey(matchCostumeId)) continue;
                string matchCharacter = currentCharacters.TryGetValue(matchCostumeId[..^3], out string matchExistingCharacter) ? matchExistingCharacter : "Unknown";

                string unreleasedCostumeStr = $"{matchCharacter} ({matchCostumeId})";
                if (!unreleasedCostumes.ContainsKey(unreleasedCostumeStr))
                {
                    unreleasedCostumes[unreleasedCostumeStr] = [];
                }

                string itemName = asset.Replace(")", "\\");

                if (!unreleasedCostumes[unreleasedCostumeStr].Contains(itemName))
                {
                    unreleasedCostumes[unreleasedCostumeStr].Add(itemName);
                }
            }
        }

        foreach ((string costume, List<string> files) in unreleasedCostumes.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{costume}".ToHeader3());
            foreach (var fileName in files.OrderBy(x => x))
            {
                Console.WriteLine(fileName);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Unreleased costumes".ToHeader3());
        Console.WriteLine("```diff");
        foreach ((string costume, List<string> _) in unreleasedCostumes.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{costume}");
        }
        Console.WriteLine("```");

        return Task.CompletedTask;
    }

    private static Dictionary<string, string> GetCurrentCharacters()
    {
        Dictionary<string, string> result = [];

        foreach (var darkCostume in MasterDb.EntityMCostumeTable.All)
        {
            if (darkCostume.CostumeId > 100000) continue;
            string characterIdStr = $"ch{darkCostume.ActorSkeletonId:000}";
            if (result.ContainsKey(characterIdStr)) continue;

            string characterNameStr = $"character.name.{darkCostume.CharacterId}".Localize(); // Lazy
            result.Add(characterIdStr, characterNameStr);
        }

        return result;
    }

    private static Dictionary<string, string> GetCurrentCostumes()
    {
        Dictionary<string, string> result = [];

        foreach (var costume in MasterDb.EntityMCostumeTable.All)
        {
            if (costume.CostumeId >= 100000) continue;

            string costumeId = CalculatorCostume.ActorAssetId(costume.CostumeId).StringId;
            result.TryAdd(costumeId, CalculatorCostume.CostumeName(costume.CostumeId));
        }

        return result;
    }
}
