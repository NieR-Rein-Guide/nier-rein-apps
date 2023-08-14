namespace NierReincarnation.Core.Dark.Component.WorldMap;

public sealed class GimmickManager
{
    #region Singleton

    private static readonly Lazy<GimmickManager> Lazy = new(() => new GimmickManager());

    public static GimmickManager Instance => Lazy.Value;

    #endregion Singleton

    private const long validStartTimeRange = 86400000;
    private const int kInvalidId = -1;
    private const float kInitSequenceRequestIntervalTimeSeconds = 10f;

    private readonly WorldMapGimmickModel _worldMapGimmickModel;

    //private readonly IGimmickService _gimmickService;
    //private readonly Empty _emptyRequest;
    //private readonly WorldMapInitSequenceScheduleResponse _worldMapInitSequenceScheduleResponse;
    //private readonly UpdateGimmickProgressRequest _updateGimmickProgressRequest;
    //private readonly WorldMapUpdateGimmickProgressResponse _worldMapUpdateGimmickProgressResponse;
    //private readonly UpdateSequenceRequest _updateSequenceRequest;
    //private readonly WorldMapUpdateSequenceResponse _worldMapUpdateSequenceResponse;
    private readonly FlowType _currentFlowType;

    private readonly int _currentChapterId;
    private readonly int _currentBackgroundAssetId;
    private readonly float _initSequenceRequestLastSuccessTime;

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
