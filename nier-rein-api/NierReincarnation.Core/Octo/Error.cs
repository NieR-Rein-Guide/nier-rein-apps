namespace NierReincarnation.Core.Octo
{
    sealed class Error
    {
        // 0x10
        public string Code { get; set; }
        // 0x18
        public string Message { get; set; }

        // RVA: 0x32FFCD8 Offset: 0x32FFCD8 VA: 0x32FFCD8
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
}
