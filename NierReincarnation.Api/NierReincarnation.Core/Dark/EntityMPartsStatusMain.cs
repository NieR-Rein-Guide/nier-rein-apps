﻿using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_status_main")]
    public class EntityMPartsStatusMain
    {
        [Key(0)] // RVA: 0x1DE06C0 Offset: 0x1DE06C0 VA: 0x1DE06C0
        public int PartsStatusMainId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE0700 Offset: 0x1DE0700 VA: 0x1DE0700
        public StatusKindType StatusKindType { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE0714 Offset: 0x1DE0714 VA: 0x1DE0714
        public StatusCalculationType StatusCalculationType { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DE0728 Offset: 0x1DE0728 VA: 0x1DE0728
        public int StatusChangeInitialValue { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DE073C Offset: 0x1DE073C VA: 0x1DE073C
        public int StatusNumericalFunctionId { get; set; } // 0x20
    }
}
