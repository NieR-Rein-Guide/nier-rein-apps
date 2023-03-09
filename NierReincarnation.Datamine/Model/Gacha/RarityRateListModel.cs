using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class RarityRateListModel
{
    public RarityType RarityType { get; set; }

    public decimal Rate { get; set; }

    public bool WithCostume { get; set; }
}
