namespace NierReincarnation.Core.Octo;

internal static class ErrorExtensions
{
    public static NamedError ToNamedError(this Error error, string name = "")
    {
        return new NamedError(name, error?.Code, error?.Message);
    }
}
