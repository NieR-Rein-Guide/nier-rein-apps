using System;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap;

public sealed class GimmickManager
{
    #region Singleton

    private static readonly Lazy<GimmickManager> Lazy = new Lazy<GimmickManager>(() => new GimmickManager());
    public static GimmickManager Instance => Lazy.Value;

    #endregion

    private static readonly long validStartTimeRange = 86400000;
    private static readonly int kInvalidId = -1;
    private static readonly float kInitSequenceRequestIntervalTimeSeconds = 10f;

    private readonly WorldMapGimmickModel _worldMapGimmickModel;
    //private readonly IGimmickService _gimmickService;
    //private readonly Empty _emptyRequest;
    //private readonly WorldMapInitSequenceScheduleResponse _worldMapInitSequenceScheduleResponse;
    //private readonly UpdateGimmickProgressRequest _updateGimmickProgressRequest;
    //private readonly WorldMapUpdateGimmickProgressResponse _worldMapUpdateGimmickProgressResponse;
    //private readonly UpdateSequenceRequest _updateSequenceRequest;
    //private readonly WorldMapUpdateSequenceResponse _worldMapUpdateSequenceResponse;
    private FlowType _currentFlowType;
    private int _currentChapterId;
    private int _currentBackgroundAssetId;
    private float _initSequenceRequestLastSuccessTime;

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
