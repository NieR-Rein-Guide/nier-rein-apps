using NierReincarnation.Core.Dark.Component.OctoInfo;

namespace NierReincarnation.Core.Dark.Kernel;

// Dark.Kernel.ApplicationContext
public sealed class ApplicationContext
{
    // 0x10
    //public Config PerformanceConfig { get; set; }

    // 0x18
    //public ApplicationTransitionState TransitionState { get; set; }

    // 0x20
    public OctoInfo OctoInfo { get; set; }

    // 0x28
    public string ReviewServerAddress { get; set; }

    // 0x30
    public int ReviewServerPort { get; set; }

    // 0x38
    public string ReviewUrlFormat { get; set; }

    // 0x40
    public string ReviewWebViewBaseUrl { get; set; }

    // 0x48
    //public ViewConfig ViewConfig { get; set; }
}
