using Art.Framework.ApiNetwork.Grpc.Api.Deck;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using System.Text.RegularExpressions;

namespace NierReincarnation.Datamine.Command;

public class ExportUnreleasedCostumesMenuCommand : AbstractMenuCommand
{
    private readonly string Pattern = "ch[0-9]{6}";

    internal static DataManager DataManager => OctoManager.Database as DataManager;

    public override Task ExecuteAsync()
    {
        Console.WriteLine();
        Dictionary<string, List<string>> unreleasedCostumes = new();
        Dictionary<string, string> currentCharacters = GetCurrentCharacters();
        Dictionary<string, string> currentCostumes = GetCurrentCostumes();

        foreach (string asset in DataManager.GetAllAssetBundleNames())
        {
            var match = Regex.Match(asset, Pattern);

            if (match.Success)
            {
                string matchCostumeId = match.Groups[0].Value;

                if (matchCostumeId.Equals("ch000000")) continue;
                if (currentCostumes.ContainsKey(matchCostumeId)) continue;
                string matchCharacter = currentCharacters.TryGetValue(matchCostumeId[..^3], out string matchExistingCharacter) ? matchExistingCharacter : "Unknown";

                string unreleasedCostumeStr = $"{matchCharacter} ({matchCostumeId})";
                if (!unreleasedCostumes.ContainsKey(unreleasedCostumeStr))
                {
                    unreleasedCostumes[unreleasedCostumeStr] = new();
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
            Console.WriteLine($"**{costume}**");
            foreach (var fileName in files.OrderBy(x => x))
            {
                Console.WriteLine(fileName);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("**Unreleased costumes**");
        Console.WriteLine("```");
        foreach ((string costume, List<string> _) in unreleasedCostumes.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{costume}");
        }
        Console.WriteLine("```");

        return Task.CompletedTask;
    }

    private static Dictionary<string, string> GetCurrentCharacters()
    {
        Dictionary<string, string> result = new();

        foreach (var darkCharacter in MasterDb.EntityMCharacterTable.All)
        {
            string characterNameStr = CalculatorCharacter.CharacterName(darkCharacter.CharacterId, true);
            if (string.IsNullOrWhiteSpace(characterNameStr)) continue;

            string characterIdStr = $"ch{darkCharacter.CharacterAssetId.ToString()[^3..]}";
            result.TryAdd(characterIdStr, characterNameStr);

            var darkCharacterSwitch = MasterDb.EntityMCharacterDisplaySwitchTable.FindByCharacterId(darkCharacter.CharacterId);

            if (darkCharacterSwitch != null)
            {
                characterIdStr = $"ch{darkCharacterSwitch.CharacterAssetId.ToString()[^3..]}";
                result.TryAdd(characterIdStr, characterNameStr);
            }
        }

        return result;
    }

    private static Dictionary<string, string> GetCurrentCostumes()
    {
        Dictionary<string, string> result = new();

        foreach (var costume in MasterDb.EntityMCostumeTable.All)
        {
            if (costume.CostumeId >= 100000) continue;

            string costumeId = CalculatorCostume.ActorAssetId(costume.CostumeId).StringId;
            result.TryAdd(costumeId, CalculatorCostume.CostumeName(costume.CostumeId));
        }

        return result;
    }
}
