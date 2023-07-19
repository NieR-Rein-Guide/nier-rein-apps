using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_ornament")]
    public class EntityMGimmickOrnament
    {
        [Key(0)]
        public int GimmickOrnamentGroupId { get; set; } // 0x10

        [Key(1)]
        public int GimmickOrnamentIndex { get; set; } // 0x14

        [Key(2)]
        public int GimmickOrnamentViewId { get; set; } // 0x18

        [Key(3)]
        public int Count { get; set; } // 0x1C

        [Key(4)]
        public int ChapterId { get; set; } // 0x20

        [Key(5)]
        public float PositionX { get; set; } // 0x24

        [Key(6)]
        public float PositionY { get; set; } // 0x28

        [Key(7)]
        public float PositionZ { get; set; } // 0x2C

        [Key(8)]
        public float Rotation { get; set; } // 0x30

        [Key(9)]
        public float Scale { get; set; } // 0x34

        [Key(10)]
        public int SortOrder { get; set; } // 0x38

        [Key(11)]
        public int AssetBackgroundId { get; set; } // 0x3C

        [Key(12)]
        public int IconDifficultyValue { get; set; } // 0x40

        [Key(13)]
        public float RotationX { get; set; } // 0x44

        [Key(14)]
        public float RotationZ { get; set; } // 0x48
    }
}
