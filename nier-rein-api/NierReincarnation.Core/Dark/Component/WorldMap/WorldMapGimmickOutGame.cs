using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap
{
    public struct WorldMapGimmickOutGame
    {
        public long StartDatetime { get; set; } // 0x0
        public long EndDatetime { get; set; }   // 0x8
        public long GimmickStartDateTime { get; set; }  // 0x10
        public long BaseDateTime { get; set; }  // 0x18
        public int GimmickSequenceScheduleId { get; set; }  
        public int NextGimmickSequenceId { get; set; }  
        public int GimmickGroupId { get; set; } 
        public int ChapterId { get; set; }  
        public int UserGimmickProgressValueBit { get; set; }    // 0x3C
        public int GimmickOrnamentCount { get; set; }   // 0x40
        public int IntervalValue { get; set; }  // 0x44
        public int MaxValue { get; set; }   // 0x48
        public float PositionX { get; set; }    // 0x4C
        public float PositionY { get; set; }    // 0x50
        public float PositionZ { get; set; }    // 0x54
        public int IconDifficultyValue { get; set; }    // 0x58
        public int GimmickOrnamentIndex { get; set; }  // 0x5C
        public int GimmickId { get; set; }  // 0x60
        public GimmickType GimmickType { get; set; }    // 0x64
        public long SequenceProgressRequireHour { get; set; }   // 0x68
        public long SequenceClearDateTime { get; set; } // 0x70
        public long SequenceProgressStartDateTime { get; set; } // 0x78
        public WorldMapGimmickSequenceProgressType SequenceProgressType { get; set; }   // 0x80
        public WorldMapEnableGimmickType EnableGimmickType { get; set; }    // 0x84
        public WorldMapEnableGimmickType EnableGimmickSequenceType { get; set; }    // 0x80

        // CUSTOM
        public int GimmickSequenceId { get; set; }
        public int GimmickFlowType { get; set; }
        public int CageOrnamentId { get; set; }

        public void Reset()
        {
            BaseDateTime = GimmickConstant.kInvalidId;
        }

        public bool IsEnable()
        {
            return (int)BaseDateTime != GimmickConstant.kInvalidId;
        }

        public int GetAvailableIntervalGimmickCount(long nowUnixTimeMilliSeconds)
        {
            var isInterval = CalculatorWorldMap.IsIntervalDropItemType(GimmickType);
            if (!isInterval && IntervalValue == 0)
                return GimmickConstant.kInvalidCount;

            //var isEndPortal = CalculatorForceOperation.IsEndPortalCageDropItem();
            //if (!isEndPortal)
            //    return !ExistNextPlayableSceneForPortal() && GimmickType == GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM;

            var baseMins = BaseDateTime / GimmickConstant.kMilliSecondsToMinutesTimes;
            var nowMins = nowUnixTimeMilliSeconds / GimmickConstant.kMilliSecondsToMinutesTimes;

            var parts = 0;
            if (IntervalValue != 0)
                parts = (int)((nowMins - baseMins) / IntervalValue);

            return parts <= MaxValue ? parts : MaxValue;
        }

        public bool IsAvailableGimmickSequence(long nowUnixTimeMilliSeconds)
        {
            return SequenceProgressRequireHour + SequenceClearDateTime <= nowUnixTimeMilliSeconds;
        }

        public bool IsAvailableGimmickSequenceStartDateTime(long nowUnixTimeMilliSeconds)
        {
            return SequenceProgressStartDateTime <= nowUnixTimeMilliSeconds;
        }
    }
}
