using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Api.Model;

public class CommonRequest
{
    public string AppVersion { get; init; } = Application.Version;

    public string Language { get; init; } = Application.SystemLanguage.ToString();

    public string OsType { get; init; } = Application.Platform.ToString("D");

    public string OsVersion { get; init; } = SystemInfo.OperatingSystem;

    public string DeviceName { get; init; } = SystemInfo.DeviceName;

    public string PlatformType { get; init; } = Application.Platform.ToString("D");

    public long RequestDatetime { get; init; } = (long)(DateTime.Now - DateTime.UnixEpoch).TotalSeconds;

    public int RequestId { get; init; } = 1;
}
