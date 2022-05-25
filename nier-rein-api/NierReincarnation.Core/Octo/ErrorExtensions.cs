namespace NierReincarnation.Core.Octo
{
    static class ErrorExtensions
    {
        public static NamedError ToNamedError(this Error error, string name = "")
        {
            return new NamedError(name, error?.Code, error?.Message);
        }
    }
}
