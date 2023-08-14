namespace NierReincarnation.Core.MasterMemory;

[AttributeUsage(AttributeTargets.Class)]
public class MemoryTableAttribute : Attribute
{
    public string TableName { get; }

    public MemoryTableAttribute(string tableName)
    {
        TableName = tableName;
    }
}
