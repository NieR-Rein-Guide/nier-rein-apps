using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_boss")]
    public class EntityMBigHuntBoss
    {
        [Key(0)] // RVA: 0x1DD6134 Offset: 0x1DD6134 VA: 0x1DD6134
        public int BigHuntBossId { get; set; }

        [Key(1)] // RVA: 0x1DD6174 Offset: 0x1DD6174 VA: 0x1DD6174
        public int BigHuntBossGradeGroupId { get; set; }

        [Key(2)] // RVA: 0x1DD6188 Offset: 0x1DD6188 VA: 0x1DD6188
        public int NameBigHuntBossTextId { get; set; }

        [Key(3)] // RVA: 0x1DD619C Offset: 0x1DD619C VA: 0x1DD619C
        public int BigHuntBossAssetId { get; set; }

        [Key(4)] // RVA: 0x1DD61B0 Offset: 0x1DD61B0 VA: 0x1DD61B0
        public AttributeType AttributeType { get; set; }
    }
}
