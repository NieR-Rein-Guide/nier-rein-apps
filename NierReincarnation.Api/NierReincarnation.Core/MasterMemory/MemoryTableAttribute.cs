using System;

namespace NierReincarnation.Core.MasterMemory
{
    // MasterMemory.MemoryTableAttribute
    class MemoryTableAttribute : Attribute
    {
        public string TableName { get; }

        public MemoryTableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
