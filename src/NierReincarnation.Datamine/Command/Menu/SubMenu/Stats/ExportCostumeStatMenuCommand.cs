﻿using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class ExportCostumeStatMenuCommand : AbstractMenuCommand<ExportCostumeStatMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCostumeStatMenuCommand(ExportCostumeStatMenuCommandArg arg) : base(arg) { }

    public override async Task ExecuteAsync(ExportCostumeStatMenuCommandArg arg)
    {
        Costume costume = await new FetchCostumeCommand().ExecuteAsync(new FetchCostumeCommandArg
        {
            EntityId = arg.CostumeId,
            Awakenings = [0, 5],
            KarmaRarityTypes = [RarityType.RARE, RarityType.S_RARE, RarityType.SS_RARE]
        });

        Console.WriteLine(costume);
    }
}

public class ExportCostumeStatMenuCommandArg
{
    public int CostumeId { get; init; }
}
