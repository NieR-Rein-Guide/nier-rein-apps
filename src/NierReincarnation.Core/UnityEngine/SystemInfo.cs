using NierReincarnation.Core.UnityEngine.Rendering;

namespace NierReincarnation.Core.UnityEngine;

public sealed class SystemInfo
{
    public static float BatteryLevel => 100f;

    public static string OperatingSystem => "Android OS 7.1.1 / API-23 (NMF26F/136)";

    public static OperatingSystemFamily OperatingSystemFamily => OperatingSystemFamily.Linux;

    public static string ProcessorType { get; }

    public static int ProcessorFrequency { get; }

    public static int ProcessorCount { get; }

    public static int SystemMemorySize { get; }

    public static string DeviceUniqueIdentifier => "35709d2a3c52d02388d12e88535f8aa0";

    public static string DeviceName => "OnePlus ONEPLUS A3010";

    public static string DeviceModel => "OnePlus ONEPLUS A3010";

    public static bool SupportsVibration => false;

    public static DeviceType DeviceType => DeviceType.Handheld;

    public static int GraphicsMemorySize => 8192;

    public static string GraphicsDeviceName { get; }

    public static string GraphicsDeviceVendor { get; }

    public static int GraphicsDeviceID { get; }

    public static int GraphicsDeviceVendorID { get; }

    public static GraphicsDeviceType GraphicsDeviceType => GraphicsDeviceType.OpenGLES3;

    public static bool GraphicsUVStartsAtTop { get; }

    public static string GraphicsDeviceVersion { get; }

    public static int GraphicsShaderLevel { get; }

    public static bool GraphicsMultiThreaded => true;

    public static bool HasHiddenSurfaceRemovalOnGPU { get; }

    public static bool SupportsShadows => true;

    public static bool SupportsMotionVectors => true;

    public static bool Supports3DRenderTextures => true;

    public static CopyTextureSupport CopyTextureSupport { get; }

    public static bool SupportsComputeShaders => true;

    public static int SupportedRenderTargetCount { get; }

    public static int SupportsMultisampledTextures { get; }

    public static bool SupportsMultisampleAutoResolve => true;

    public static bool UsesReversedZBuffer { get; }

    public static int MaxTextureSize { get; }

    public static bool UsesLoadStoreActions { get; }
}
