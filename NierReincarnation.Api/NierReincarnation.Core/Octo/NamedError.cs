namespace NierReincarnation.Core.Octo
{
    class NamedError : AssetLoaderError
    {
        // 0x10
        public string Name { get; set; }
        // 0x18
        public string Code { get; set; }
        // 0x20
        public string Message { get; set; }

        public NamedError(string name, string code, string message)
        {
            Name = name;
            Code = code;
            Message = message;
        }

        public static NamedError CreateWithFormat(string name, string code, string format, string[] args)
        {
            return new NamedError(name, code, string.Format(format, args));
        }

        public override string ToString()
        {
            return $"[Octo.Error: Name={Name}, Code={Code}, Message='{Message}']";
        }

        public static NamedError CreateDatabaseNotFoundError(string name)
        {
            return new NamedError(name, "octo.database.name_not_found", "Not found in database");
        }
    }
}
