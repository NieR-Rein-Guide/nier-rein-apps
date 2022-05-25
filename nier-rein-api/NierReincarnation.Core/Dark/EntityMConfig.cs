using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // Dark.EntityMConfig
    [MessagePackObject]
    [MemoryTable("m_config")]
    public class EntityMConfig
    {
        // 0x10
        [Key(0)]
        public string ConfigKey { get; set; }
        // 0x18
        [Key(1)]
        public string Value { get; set; }

        public EntityMConfig(string key, string value)
        {
            ConfigKey = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"ConfigKey, Value {ConfigKey}, {Value}";
        }
    }
}
