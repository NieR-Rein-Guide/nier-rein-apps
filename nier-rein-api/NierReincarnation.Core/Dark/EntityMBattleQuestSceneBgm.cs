﻿using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_quest_scene_bgm")]
    public class EntityMBattleQuestSceneBgm
    {
        [Key(0)] // RVA: 0x1DD9390 Offset: 0x1DD9390 VA: 0x1DD9390
        public int QuestSceneId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD93D0 Offset: 0x1DD93D0 VA: 0x1DD93D0
        public int StartWaveNumber { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DD9410 Offset: 0x1DD9410 VA: 0x1DD9410
        public int BgmId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DD9424 Offset: 0x1DD9424 VA: 0x1DD9424
        public int Stem { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DD9438 Offset: 0x1DD9438 VA: 0x1DD9438
        public int TrackNumber { get; set; } // 0x20
	}
}
