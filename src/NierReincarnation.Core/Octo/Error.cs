namespace NierReincarnation.Core.Octo;

internal sealed class Error
{
    public string Code { get; set; }

    public string Message { get; set; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error CreateWithFormat(string code, string format, params string[] args)
    {
        return new Error(code, string.Format(format, args));
    }

    public override string ToString()
    {
        return $"[Octo.Error: Code={Code}, Message='{Message}']";
    }
}
