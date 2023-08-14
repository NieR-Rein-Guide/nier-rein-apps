using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Maintenance
{
    public MaintenanceBlockFunctionType Type { get; init; }

    public string ApiPath { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<string> AffectedEntities { get; init; }
}
