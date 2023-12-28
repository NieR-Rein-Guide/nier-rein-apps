using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Api.Localizations;

public interface ITextLocalizer
{
    Task<Dictionary<string, string>> CreateAsync(SystemLanguage lang = SystemLanguage.English);
}
