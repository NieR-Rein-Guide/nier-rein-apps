using NierReincarnation.Core.Dark.Generated.Type;
using System;

namespace NierReincarnation.Context.Models;

public class Banner
{
    public int GachaId { get; internal set; }

    public string Name { get; internal set; }

    public DateTime StartTime { get; internal set; }

    public DateTime EndTime { get; internal set; }

    public GachaLabelType GachaLabelType { get; internal set; }

    public GachaModeType GachaModeType { get; internal set; }

    public GachaAutoResetType GachaAutoResetType { get; internal set; }

    public GachaDecorationType GachaDecorationType { get; internal set; }
}
