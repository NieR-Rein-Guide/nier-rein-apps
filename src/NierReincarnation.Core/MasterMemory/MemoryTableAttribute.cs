using Newtonsoft.Json.Serialization;

namespace NierReincarnation.Core.MasterMemory;

[AttributeUsage(AttributeTargets.Class)]
public class MemoryTableAttribute : Attribute
{
    public string TableName { get; }

    public MemoryTableAttribute(string tableName)
    {
        SnakeCaseNamingStrategy snakeCaseNamingStrategy = new();
        TableName = snakeCaseNamingStrategy.GetPropertyName(tableName, false).Split("_", 2).LastOrDefault();
    }
}
