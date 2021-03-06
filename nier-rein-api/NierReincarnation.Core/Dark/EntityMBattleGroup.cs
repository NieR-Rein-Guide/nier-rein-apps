using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_group")]
    public class EntityMBattleGroup
    {
        [Key(0)] // RVA: 0x1DD7AEC Offset: 0x1DD7AEC VA: 0x1DD7AEC
        public int BattleGroupId { get; set; }
        [Key(1)] // RVA: 0x1DD7B2C Offset: 0x1DD7B2C VA: 0x1DD7B2C
        public int WaveNumber { get; set; }
        [Key(2)] // RVA: 0x1DD7B6C Offset: 0x1DD7B6C VA: 0x1DD7B6C
        public int BattleId { get; set; }
        [Key(3)] // RVA: 0x1DD7B80 Offset: 0x1DD7B80 VA: 0x1DD7B80
        public int WaveStartActAssetId { get; set; }
        [Key(4)] // RVA: 0x1DD7B94 Offset: 0x1DD7B94 VA: 0x1DD7B94
        public int WaveEndActAssetId { get; set; }
        [Key(5)] // RVA: 0x1DD7BA8 Offset: 0x1DD7BA8 VA: 0x1DD7BA8
        public int BattleCameraControllerAssetId { get; set; }
        [Key(6)] // RVA: 0x1DD7BBC Offset: 0x1DD7BBC VA: 0x1DD7BBC
        public int BattlePointIndex { get; set; }
        [Key(7)] // RVA: 0x1DD7BD0 Offset: 0x1DD7BD0 VA: 0x1DD7BD0
        public int BattleStartCameraType { get; set; }
	}
}
