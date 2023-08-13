using NierReincarnation.Core.Dark.Component.OctoInfo;

namespace NierReincarnation.Core.Dark.Kernel;

public sealed class ApplicationContext
{
    public OctoInfo OctoInfo { get; set; }

    public string ReviewServerAddress { get; set; }

    public int ReviewServerPort { get; set; }

    public string ReviewUrlFormat { get; set; }

    public string ReviewWebViewBaseUrl { get; set; }
}
