using System;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap
{
    public sealed class GimmickManager
    {
        #region Singleton

        private static readonly Lazy<GimmickManager> Lazy = new Lazy<GimmickManager>(() => new GimmickManager());
        public static GimmickManager Instance => Lazy.Value;

        #endregion

        private static readonly long validStartTimeRange = 86400000; // 0x0
        private static readonly int kInvalidId = -1; // 0x8
        private static readonly float kInitSequenceRequestIntervalTimeSeconds = 10f; // 0xC

        private readonly WorldMapGimmickModel _worldMapGimmickModel; // 0x10
        //private readonly IGimmickService _gimmickService; // 0x18
        //private readonly Empty _emptyRequest; // 0x20
        //private readonly WorldMapInitSequenceScheduleResponse _worldMapInitSequenceScheduleResponse; // 0x28
        //private readonly UpdateGimmickProgressRequest _updateGimmickProgressRequest; // 0x30
        //private readonly WorldMapUpdateGimmickProgressResponse _worldMapUpdateGimmickProgressResponse; // 0x38
        //private readonly UpdateSequenceRequest _updateSequenceRequest; // 0x40
        //private readonly WorldMapUpdateSequenceResponse _worldMapUpdateSequenceResponse; // 0x48
        private FlowType _currentFlowType; // 0x50
        private int _currentChapterId; // 0x54
        private int _currentBackgroundAssetId; // 0x58
        private float _initSequenceRequestLastSuccessTime; // 0x5C

        public GimmickManager()
        {
            _worldMapGimmickModel = new WorldMapGimmickModel();

            _currentChapterId = kInvalidId;
            _currentBackgroundAssetId = kInvalidId;

            _worldMapGimmickModel.OnInitialize();
        }

        public WorldMapGimmickModelResultType GenerateWorldMapGimmickOutGameAsync(int chapterId)
        {
            return _worldMapGimmickModel.GenerateWorldMapGimmickOutGameAsync(chapterId, validStartTimeRange);
        }

        public int GetWorldMapGimmickOutGamesCount()
        {
            return _worldMapGimmickModel.GetWorldMapGimmickOutGamesCount();
        }

        public void GetWorldMapGimmickOutGame(int index, out WorldMapGimmickOutGame worldMapGimmickOutGame)
        {
            _worldMapGimmickModel.GetWorldMapGimmickOutGame(index, out worldMapGimmickOutGame);
        }
    }
}
