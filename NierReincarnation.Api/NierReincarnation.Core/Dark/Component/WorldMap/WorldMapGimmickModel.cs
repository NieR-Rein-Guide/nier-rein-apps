using System.Linq;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Component.WorldMap;

public sealed class WorldMapGimmickModel
{
    private static readonly int kInvalidId = -1;
    private static readonly int kTerminalSequenceGroupId = 0;
    public static readonly int kTerminalSequenceId = 0;
    private static readonly int kPortalCageChapterId = 0;
    private static readonly int MaxGimmickOrnament = 0x400;
    private static readonly int MaxGimmickSequenceGroup = 0x400;
    private static readonly int MaxGimmickSequence = 0x400;
    private static readonly int MaxGimmickSequenceSchedule = 0x400;
    private static readonly int MaxGimmick = 0x400;
    private static readonly int MaxGimmickGroup = 0x400;
    private static readonly int MaxGimmickSequenceRewardGroup = 0x400;
    private static readonly int MaxGimmickInterval = 0x400;
    private static readonly int MaxEvaluateCondition = 0x400;
    private static readonly int MaxEvaluateConditionValueGroup = 0x400;
    private static readonly int MaxUserGimmick = 0x400;
    private static readonly int MaxUserGimmickSequence = 0x400;
    private static readonly int MaxUserGimmickOrnamentProgress = 0x400;
    private static readonly int MaxGimmickOrnamentCage = 0x80;
    private static readonly int MaxWorldMapGimmickOutGame = 0x400;
    //private static readonly int MaxProcessAwait = 0x32;

    private GimmickOrnament[] _gimmickOrnamentsMaster;
    private GimmickSequenceGroup[] _gimmickSequenceGroupsMaster;
    private GimmickSequence[] _gimmickSequencesMaster;
    private GimmickSequenceRewardGroup[] _gimmickSequenceRewardGroupsMaster;
    private GimmickSequenceSchedule[] _gimmickSequenceScheduleMaster;
    private Gimmick[] _gimmickMaster;
    private GimmickGroup[] _gimmickGroupMaster;
    private GimmickInterval[] _gimmickIntervalMaster;
    private EvaluateCondition[] _evaluateConditionMaster;
    private EvaluateConditionValueGroup[] _evaluateConditionValueGroupMaster;
    private UserGimmick[] _userGimmickMaster;
    private UserGimmickSequence[] _userGimmickSequenceMaster;
    private UserGimmickOrnamentProgress[] _userGimmickOrnamentProgressMaster;
    private GimmickOrnament[] _gimmickOrnamentsCache;
    private GimmickSequenceGroup[] _gimmickSequenceGroupsCache;
    private GimmickSequence[] _gimmickSequencesCache;
    private GimmickSequenceRewardGroup[] _gimmickSequenceRewardGroupsCache;
    private GimmickSequenceSchedule[] _gimmickSequenceScheduleCache;
    private Gimmick[] _gimmickCache;
    private GimmickGroup[] _gimmickGroupCache;
    private GimmickInterval[] _gimmickIntervalCache;
    private EvaluateCondition[] _evaluateConditionCache;
    private EvaluateConditionValueGroup[] _evaluateConditionValueGroupCache;
    private UserGimmick[] _userGimmickCache;
    private UserGimmickSequence[] _userGimmickSequenceCache;
    private UserGimmickOrnamentProgress[] _userGimmickOrnamentProgressCache;
    private GimmickOrnamentCage[] _gimmickOrnamentCagesMaster;
    private GimmickOrnamentCage[] _gimmickOrnamentCagesCache;
    private WorldMapGimmickOutGame[] _worldMapGimmickOutGamesMaster;
    private WorldMapGimmickOutGame[] _worldMapGimmickOutGamesCache;
    private int _gimmickOrnamentsCacheCount;
    private int _gimmickSequenceGroupsCacheCount;
    private int _gimmickSequencesCacheCount;
    private int _gimmickSequenceScheduleCacheCount;
    private int _gimmickCacheCount;
    private int _gimmickGroupCacheCount;
    private int _gimmickIntervalCacheCount;
    private int _gimmickOrnamentCagesCacheCount;
    private int _worldMapGimmickOutGameCacheCount;
    private int _userGimmickCacheCount;
    private int _userGimmickSequenceCacheCount;
    private int _userGimmickOrnamentProgressCacheCount;

    public void OnInitialize()
    {
        _gimmickOrnamentsMaster = new GimmickOrnament[MaxGimmickOrnament];
        _gimmickSequenceGroupsMaster = new GimmickSequenceGroup[MaxGimmickSequenceGroup];
        _gimmickSequencesMaster = new GimmickSequence[MaxGimmickSequence];
        _gimmickSequenceRewardGroupsMaster = new GimmickSequenceRewardGroup[MaxGimmickSequenceRewardGroup];
        _gimmickSequenceScheduleMaster = new GimmickSequenceSchedule[MaxGimmickSequenceSchedule];
        _gimmickMaster = new Gimmick[MaxGimmick];
        _gimmickGroupMaster = new GimmickGroup[MaxGimmickGroup];
        _gimmickIntervalMaster = new GimmickInterval[MaxGimmickInterval];
        _evaluateConditionMaster = new EvaluateCondition[MaxEvaluateCondition];
        _evaluateConditionValueGroupMaster = new EvaluateConditionValueGroup[MaxEvaluateConditionValueGroup];
        _userGimmickMaster = new UserGimmick[MaxUserGimmick];
        _userGimmickSequenceMaster = new UserGimmickSequence[MaxUserGimmickSequence];
        _userGimmickOrnamentProgressMaster = new UserGimmickOrnamentProgress[MaxUserGimmickOrnamentProgress];
        _gimmickOrnamentsCache = new GimmickOrnament[MaxGimmickOrnament];
        _gimmickSequencesCache = new GimmickSequence[MaxGimmickSequenceGroup];
        _gimmickSequenceGroupsCache = new GimmickSequenceGroup[MaxGimmickSequence];
        _gimmickSequenceRewardGroupsCache = new GimmickSequenceRewardGroup[MaxGimmickSequenceRewardGroup];
        _gimmickSequenceScheduleCache = new GimmickSequenceSchedule[MaxGimmickSequenceSchedule];
        _gimmickCache = new Gimmick[MaxGimmick];
        _gimmickGroupCache = new GimmickGroup[MaxGimmickGroup];
        _gimmickIntervalCache = new GimmickInterval[MaxGimmickInterval];
        _evaluateConditionCache = new EvaluateCondition[MaxEvaluateCondition];
        _evaluateConditionValueGroupCache = new EvaluateConditionValueGroup[MaxEvaluateConditionValueGroup];
        _userGimmickCache = new UserGimmick[MaxUserGimmick];
        _userGimmickSequenceCache = new UserGimmickSequence[MaxUserGimmickSequence];
        _userGimmickOrnamentProgressCache = new UserGimmickOrnamentProgress[MaxUserGimmickOrnamentProgress];
        _gimmickOrnamentCagesMaster = new GimmickOrnamentCage[MaxGimmickOrnamentCage];
        _gimmickOrnamentCagesCache = new GimmickOrnamentCage[MaxGimmickOrnamentCage];
        _worldMapGimmickOutGamesMaster = new WorldMapGimmickOutGame[MaxWorldMapGimmickOutGame];
        _worldMapGimmickOutGamesCache = new WorldMapGimmickOutGame[MaxWorldMapGimmickOutGame];

        ResetAll();
    }

    #region Generate

    public WorldMapGimmickModelResultType GenerateWorldMapGimmickOutGameAsync(int chapterId, long validStartTimeRange)
    {
        ResetWorldMapGimmickOutGames();

        var ornamentTable = DatabaseDefine.Master.EntityMGimmickOrnamentTable;
        var gimmickTable = DatabaseDefine.Master.EntityMGimmickTable;
        var gimmickGroupTable = DatabaseDefine.Master.EntityMGimmickGroupTable;
        var gimmickSequenceTable = DatabaseDefine.Master.EntityMGimmickSequenceTable;
        var gimmickSequenceSchedule = DatabaseDefine.Master.EntityMGimmickSequenceScheduleTable;
        var gimmickIntervalTable = DatabaseDefine.Master.EntityMGimmickIntervalTable;

        var userOrnamentTable = DatabaseDefine.User.EntityIUserGimmickOrnamentProgressTable;
        var userGimmickTable = DatabaseDefine.User.EntityIUserGimmickTable;
        var userGimmickSequenceTable = DatabaseDefine.User.EntityIUserGimmickSequenceTable;

        var userId = CalculatorStateUser.GetUserId();
        var unixNow = CalculatorDateTime.UnixTimeNow();

        foreach (var ornament in ornamentTable.All)
        {
            if (ornament.ChapterId != chapterId)
                continue;

            var gimmicks = gimmickTable.All.Where(x => x.GimmickOrnamentGroupId == ornament.GimmickOrnamentGroupId);
            foreach (var gimmick in gimmicks)
            {
                var intervalValue = 0;
                var maxValue = 0;
                if (CalculatorWorldMap.IsIntervalDropItemType(gimmick.GimmickType))
                {
                    var gimmickInterval = gimmickIntervalTable.All.FirstOrDefault(x => x.GimmickId == gimmick.GimmickId);
                    if (gimmickInterval != null)
                    {
                        intervalValue = gimmickInterval.IntervalValue;
                        maxValue = gimmickInterval.MaxValue;
                    }
                }

                var gimmickGroups = gimmickGroupTable.All.Where(x => x.GimmickId == gimmick.GimmickId);
                foreach (var gimmickGroup in gimmickGroups)
                {
                    var gimmickSchedules = gimmickSequenceSchedule.All.Where(x => x.EndDatetime >= unixNow &&
                        unixNow + validStartTimeRange >= x.StartDatetime);

                    foreach (var gimmickSchedule in gimmickSchedules)
                    {
                        var sequenceId = gimmickSchedule.FirstGimmickSequenceId;
                        do
                        {
                            var nextSequenceId = GetNextGimmickSequenceId(sequenceId);
                            var gimmickSequence = gimmickSequenceTable.All.FirstOrDefault(x =>
                                x.GimmickGroupId == gimmickGroup.GimmickGroupId &&
                                x.GimmickSequenceId == sequenceId);
                            if (gimmickSequence != null)
                            {
                                // Determine time frames
                                var progressBaseDatetime = 0L;
                                var progressValueBit = 0;
                                var enableGimmickType = WorldMapEnableGimmickType.None;
                                var startDatetime = 0L;

                                if (ornament.ChapterId == kPortalCageChapterId)
                                {
                                    //L340
                                    // HINT: Ignore for now
                                }
                                else
                                {
                                    // Determine baseDate time and progress value
                                    var userOrnamentProgress = userOrnamentTable.FindByUserId((userId,
                                        gimmickSchedule.GimmickSequenceScheduleId,
                                        gimmickSchedule.FirstGimmickSequenceId, gimmick.GimmickId,
                                        ornament.GimmickOrnamentIndex));
                                    if (userOrnamentProgress != null)
                                    {
                                        progressBaseDatetime = userOrnamentProgress.BaseDatetime;
                                        progressValueBit = userOrnamentProgress.ProgressValueBit;
                                    }

                                    switch (gimmick.GimmickType)
                                    {
                                        case GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT:
                                            var table = DatabaseDefine.User.EntityIUserCageOrnamentRewardTable;
                                            var ornamentReward = table.FindByUserIdAndCageOrnamentId((userId, ornament.GimmickOrnamentViewId));
                                            if (ornamentReward != null)
                                            {
                                                progressValueBit = 1;
                                                progressBaseDatetime = 0;
                                            }

                                            enableGimmickType = ornamentReward != null ? WorldMapEnableGimmickType.Cleared : WorldMapEnableGimmickType.InProgress;
                                            break;

                                        case GimmickType.MAP_ONLY_HIDE_OBELISK:
                                            var isReleased = CalculatorWorldMap.IsReleasedHideObelisk(userId, gimmickGroup.GimmickId, ornament.GimmickOrnamentIndex);
                                            enableGimmickType = isReleased ? WorldMapEnableGimmickType.InProgress : WorldMapEnableGimmickType.NotStart;
                                            break;

                                        default:
                                            enableGimmickType = WorldMapEnableGimmickType.NotStart;
                                            startDatetime = 0;

                                            var userGimmick = userGimmickTable.FindByUserId((userId,
                                                gimmickSchedule.GimmickSequenceScheduleId,
                                                gimmickSchedule.FirstGimmickSequenceId, gimmick.GimmickId));
                                            if (userGimmick != null)
                                            {
                                                startDatetime = userGimmick.StartDatetime;
                                                enableGimmickType = WorldMapEnableGimmickType.InProgress;
                                                if (userGimmick.IsGimmickCleared)
                                                    enableGimmickType = WorldMapEnableGimmickType.Cleared;
                                            }

                                            break;
                                    }
                                }

                                // Determine clear state
                                var clearDateTime = 0L;
                                var enableGimmickSequenceType = WorldMapEnableGimmickType.NotStart;

                                var userGimmickSequence = userGimmickSequenceTable.FindByUserId((userId, gimmickSchedule.GimmickSequenceScheduleId));
                                if (userGimmickSequence != null)
                                {
                                    clearDateTime = userGimmickSequence.ClearDatetime;
                                    enableGimmickSequenceType = WorldMapEnableGimmickType.InProgress;
                                    if (userGimmickSequence.IsGimmickSequenceCleared)
                                        enableGimmickSequenceType = WorldMapEnableGimmickType.Cleared;
                                }

                                // Determine progress
                                var sequenceProgressType = GetGimmickSequenceProgressType(gimmickSequence.ProgressRequireHour, gimmickSequence.ProgressStartDatetime);

                                // Add world map gimmick
                                var isAdded = TryAddWorldMapGimmickOutGame(new WorldMapGimmickOutGame
                                {
                                    // Schedule
                                    StartDatetime = gimmickSchedule.StartDatetime,
                                    EndDatetime = gimmickSchedule.EndDatetime,
                                    GimmickSequenceScheduleId = gimmickSchedule.GimmickSequenceScheduleId,
                                    GimmickStartDateTime = startDatetime,

                                    // Next Sequence ID
                                    GimmickSequenceId = gimmickSequence.GimmickSequenceId,
                                    GimmickFlowType = gimmickSequence.FlowType,
                                    NextGimmickSequenceId = GetNextGimmickSequenceId(gimmickSequence.GimmickSequenceId),

                                    // GimmickSequence
                                    SequenceProgressStartDateTime = gimmickSequence.ProgressStartDatetime,
                                    SequenceProgressRequireHour = gimmickSequence.ProgressRequireHour,

                                    // GimmickGroup
                                    GimmickGroupId = gimmickGroup.GimmickGroupId,

                                    // Gimmick
                                    GimmickId = gimmick.GimmickId,
                                    GimmickType = gimmick.GimmickType,

                                    // Interval
                                    IntervalValue = intervalValue,
                                    MaxValue = maxValue,

                                    // Chapter ID
                                    ChapterId = chapterId,

                                    // Ornament
                                    PositionX = ornament.PositionX,
                                    PositionY = ornament.PositionY,
                                    PositionZ = ornament.PositionZ,
                                    GimmickOrnamentIndex = ornament.GimmickOrnamentIndex,
                                    GimmickOrnamentCount = ornament.Count,
                                    IconDifficultyValue = ornament.IconDifficultyValue,
                                    CageOrnamentId = ornament.GimmickOrnamentViewId,

                                    // OrnamentProgress
                                    BaseDateTime = progressBaseDatetime,
                                    UserGimmickProgressValueBit = progressValueBit,
                                    EnableGimmickType = enableGimmickType,

                                    // Clear state
                                    EnableGimmickSequenceType = enableGimmickSequenceType,
                                    SequenceClearDateTime = clearDateTime,

                                    // Progress
                                    SequenceProgressType = sequenceProgressType,
                                });

                                if (!isAdded)
                                    return WorldMapGimmickModelResultType.OutOfRange;
                            }

                            sequenceId = nextSequenceId;
                        } while (sequenceId != kTerminalSequenceId);
                    }
                }
            }
        }

        FetchWorldMapGimmickOutGamesCache();

        return WorldMapGimmickModelResultType.Success;
    }

    public WorldMapGimmickModelResultType GenerateWorldMapDataFromMasterDataAsync()
    {
        var res = GenerateGimmickAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickSequenceScheduleAsync(CalculatorDateTime.UnixTimeNow());
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickSequenceGroupAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickSequenceAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickSequenceRewardGroupAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickOrnamentAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickGroupAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateGimmickIntervalAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateEvaluateConditionAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateEvaluateConditionValueGroupAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateUserGimmickAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        res = GenerateUserGimmickSequenceAsync();
        if (res != WorldMapGimmickModelResultType.Success)
            return res;

        return GenerateUserGimmickOrnamentProgressAsync();
    }

    private WorldMapGimmickModelResultType GenerateGimmickAsync()
    {
        ResetGimmick();

        var table = DatabaseDefine.Master.EntityMGimmickTable;
        foreach (var item in table.All)
        {
            var itemStruct = new Gimmick
            {
                GimmickId = item.GimmickId,
                GimmickType = item.GimmickType,
                GimmickOrnamentGroupId = item.GimmickOrnamentGroupId
            };

            if (!TryAddGimmick(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickSequenceScheduleAsync(long nowUnixTime)
    {
        ResetGimmickSequenceSchedule();

        var table = DatabaseDefine.Master.EntityMGimmickSequenceScheduleTable;
        foreach (var item in table.All)
        {
            if (item.EndDatetime <= nowUnixTime)
                continue;

            var itemStruct = new GimmickSequenceSchedule
            {
                GimmickSequenceScheduleId = item.GimmickSequenceScheduleId,
                FirstGimmickSequenceId = item.FirstGimmickSequenceId,
                StartDatetime = item.StartDatetime,
                EndDatetime = item.EndDatetime
            };

            if (!TryAddGimmickSequenceSchedule(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickSequenceGroupAsync()
    {
        ResetGimmickSequenceGroup();

        var table = DatabaseDefine.Master.EntityMGimmickSequenceGroupTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickSequenceGroup
            {
                GimmickSequenceGroupId = item.GimmickSequenceGroupId,
                GimmickSequenceId = item.GimmickSequenceId
            };

            if (!TryAddGimmickSequenceGroup(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickSequenceAsync()
    {
        ResetGimmickSequence();

        var table = DatabaseDefine.Master.EntityMGimmickSequenceTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickSequence
            {
                GimmickSequenceId = item.GimmickSequenceId,
                GimmickGroupId = item.GimmickGroupId,
                FlowType = item.FlowType,
                NextGimmickSequenceGroupId = item.NextGimmickSequenceGroupId,
                ProgressRequireHour = item.ProgressRequireHour,
                ProgressStartDatetime = item.ProgressStartDatetime
            };

            if (!TryAddGimmickSequence(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickSequenceRewardGroupAsync()
    {
        ResetGimmickSequenceRewardGroup();

        var table = DatabaseDefine.Master.EntityMGimmickSequenceRewardGroupTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickSequenceRewardGroup
            {
                GimmickSequenceRewardGroupId = item.GimmickSequenceRewardGroupId
            };

            if (!TryAddGimmickSequenceRewardGroup(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickOrnamentAsync()
    {
        ResetGimmickOrnament();

        var table = DatabaseDefine.Master.EntityMGimmickOrnamentTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickOrnament
            {
                ChapterId = item.ChapterId,
                BackgroundId = item.AssetBackgroundId,
                GimmickOrnamentGroupId = item.GimmickOrnamentGroupId,
                SortOrder = item.SortOrder,
                GimmickOrnamentIndex = item.GimmickOrnamentIndex,
                GimmickOrnamentViewId = item.GimmickOrnamentViewId,
                IconDifficultyValue = item.IconDifficultyValue,
                OrnamentCount = item.Count,
                PositionX = item.PositionX,
                PositionY = item.PositionY,
                PositionZ = item.PositionZ,
                Rotation = item.Rotation,
                Scale = item.Rotation
            };

            if (!TryAddGimmickOrnament(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickGroupAsync()
    {
        ResetGimmickGroup();

        var table = DatabaseDefine.Master.EntityMGimmickGroupTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickGroup
            {
                GimmickId = item.GimmickId,
                GimmickGroupId = item.GimmickGroupId
            };

            if (!TryAddGimmickGroup(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateGimmickIntervalAsync()
    {
        ResetGimmickInterval();

        var table = DatabaseDefine.Master.EntityMGimmickIntervalTable;
        foreach (var item in table.All)
        {
            var itemStruct = new GimmickInterval
            {
                GimmickId = item.GimmickId,
                InitialValue = item.InitialValue,
                IntervalValue = item.IntervalValue,
                MaxValue = item.MaxValue
            };

            if (!TryAddGimmickInterval(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateEvaluateConditionAsync()
    {
        ResetEvaluateCondition();

        var table = DatabaseDefine.Master.EntityMEvaluateConditionTable;
        foreach (var item in table.All)
        {
            var itemStruct = new EvaluateCondition
            {
                EvaluateConditionId = item.EvaluateConditionId
            };

            if (!TryAddEvaluateCondition(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    private WorldMapGimmickModelResultType GenerateEvaluateConditionValueGroupAsync()
    {
        ResetEvaluateConditionValueGroup();

        var table = DatabaseDefine.Master.EntityMEvaluateConditionValueGroupTable;
        foreach (var item in table.All)
        {
            var itemStruct = new EvaluateConditionValueGroup
            {
                EvaluateConditionValueGroupId = item.EvaluateConditionValueGroupId
            };

            if (!TryAddEvaluateConditionValueGroup(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    public WorldMapGimmickModelResultType GenerateUserGimmickAsync()
    {
        ResetUserGimmick();

        var table = DatabaseDefine.User.EntityIUserGimmickTable;
        foreach (var item in table.All)
        {
            var itemStruct = new UserGimmick
            {
                UserId = item.UserId,
                GimmickId = item.GimmickId,
                GimmickSequenceId = item.GimmickSequenceId,
                GimmickSequenceScheduleId = item.GimmickSequenceScheduleId,
                IsGimmickCleared = item.IsGimmickCleared,
                StartDateTime = item.StartDatetime
            };

            if (!TryAddUserGimmick(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    public WorldMapGimmickModelResultType GenerateUserGimmickSequenceAsync()
    {
        ResetUserGimmickSequence();

        var table = DatabaseDefine.User.EntityIUserGimmickSequenceTable;
        foreach (var item in table.All)
        {
            var itemStruct = new UserGimmickSequence
            {
                UserId = item.UserId,
                GimmickSequenceId = item.GimmickSequenceId,
                GimmickSequenceScheduleId = item.GimmickSequenceScheduleId,
                ClearDateTime = item.ClearDatetime,
                IsGimmickSequenceCleared = item.IsGimmickSequenceCleared
            };

            if (!TryAddUserGimmickSequence(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    public WorldMapGimmickModelResultType GenerateUserGimmickOrnamentProgressAsync()
    {
        ResetUserGimmickOrnamentProgress();

        var table = DatabaseDefine.User.EntityIUserGimmickOrnamentProgressTable;
        foreach (var item in table.All)
        {
            var itemStruct = new UserGimmickOrnamentProgress
            {
                UserId = item.UserId,
                GimmickId = item.GimmickId,
                GimmickSequenceId = item.GimmickSequenceId,
                GimmickOrnamentIndex = item.GimmickOrnamentIndex,
                GimmickSequenceScheduleId = item.GimmickSequenceScheduleId,
                BaseDatetime = item.BaseDatetime,
                ProgressValueBit = item.ProgressValueBit
            };

            if (!TryAddUserGimmickOrnamentProgress(itemStruct))
                return WorldMapGimmickModelResultType.OutOfRange;
        }

        return WorldMapGimmickModelResultType.Success;
    }

    #endregion

    #region TryAdd

    private bool TryAddGimmick(Gimmick gimmick)
    {
        for (var i = 0; i < MaxGimmick; i++)
        {
            if (!_gimmickMaster[i].IsEnable())
            {
                _gimmickMaster[i] = gimmick;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickSequenceSchedule(GimmickSequenceSchedule gimmickSequenceSchedule)
    {
        for (var i = 0; i < MaxGimmickSequenceSchedule; i++)
        {
            if (!_gimmickSequenceScheduleMaster[i].IsEnable())
            {
                _gimmickSequenceScheduleMaster[i] = gimmickSequenceSchedule;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickSequenceGroup(GimmickSequenceGroup gimmickSequenceGroups)
    {
        for (var i = 0; i < MaxGimmickSequenceGroup; i++)
        {
            if (!_gimmickSequenceGroupsMaster[i].IsEnable())
            {
                _gimmickSequenceGroupsMaster[i] = gimmickSequenceGroups;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickSequence(in GimmickSequence gimmickSequences)
    {
        for (var i = 0; i < MaxGimmickSequence; i++)
        {
            if (!_gimmickSequencesMaster[i].IsEnable())
            {
                _gimmickSequencesMaster[i] = gimmickSequences;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickSequenceRewardGroup(GimmickSequenceRewardGroup gimmickSequenceRewardGroups)
    {
        for (var i = 0; i < MaxGimmickSequenceRewardGroup; i++)
        {
            if (!_gimmickSequenceRewardGroupsMaster[i].IsEnable())
            {
                _gimmickSequenceRewardGroupsMaster[i] = gimmickSequenceRewardGroups;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickOrnament(GimmickOrnament gimmickOrnaments)
    {
        for (var i = 0; i < MaxGimmickOrnament; i++)
        {
            if (!_gimmickOrnamentsMaster[i].IsEnable())
            {
                _gimmickOrnamentsMaster[i] = gimmickOrnaments;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickGroup(GimmickGroup gimmickGroup)
    {
        for (var i = 0; i < MaxGimmickGroup; i++)
        {
            if (!_gimmickGroupMaster[i].IsEnable())
            {
                _gimmickGroupMaster[i] = gimmickGroup;
                return true;
            }
        }

        return false;
    }

    private bool TryAddGimmickInterval(GimmickInterval gimmickInterval)
    {
        for (var i = 0; i < MaxGimmickInterval; i++)
        {
            if (!_gimmickIntervalMaster[i].IsEnable())
            {
                _gimmickIntervalMaster[i] = gimmickInterval;
                return true;
            }
        }

        return false;
    }

    private bool TryAddEvaluateCondition(EvaluateCondition evaluateCondition)
    {
        for (var i = 0; i < MaxEvaluateCondition; i++)
        {
            if (!_evaluateConditionMaster[i].IsEnable())
            {
                _evaluateConditionMaster[i] = evaluateCondition;
                return true;
            }
        }

        return false;
    }

    private bool TryAddEvaluateConditionValueGroup(in EvaluateConditionValueGroup evaluateConditionValueGroup)
    {
        for (var i = 0; i < MaxEvaluateConditionValueGroup; i++)
        {
            if (!_evaluateConditionValueGroupMaster[i].IsEnable())
            {
                _evaluateConditionValueGroupMaster[i] = evaluateConditionValueGroup;
                return true;
            }
        }

        return false;
    }

    private bool TryAddUserGimmick(UserGimmick userGimmick)
    {
        for (var i = 0; i < MaxUserGimmick; i++)
        {
            if (!_userGimmickMaster[i].IsEnable())
            {
                _userGimmickMaster[i] = userGimmick;
                return true;
            }
        }

        return false;
    }

    private bool TryAddUserGimmickSequence(UserGimmickSequence userGimmickSequence)
    {
        for (var i = 0; i < MaxUserGimmickSequence; i++)
        {
            if (!_userGimmickSequenceMaster[i].IsEnable())
            {
                _userGimmickSequenceMaster[i] = userGimmickSequence;
                return true;
            }
        }

        return false;
    }

    private bool TryAddUserGimmickOrnamentProgress(UserGimmickOrnamentProgress userGimmickOrnamentProgress)
    {
        for (var i = 0; i < MaxUserGimmickOrnamentProgress; i++)
        {
            if (!_userGimmickOrnamentProgressMaster[i].IsEnable())
            {
                _userGimmickOrnamentProgressMaster[i] = userGimmickOrnamentProgress;
                return true;
            }
        }

        return false;
    }

    private bool TryAddWorldMapGimmickOutGame(WorldMapGimmickOutGame worldMapGimmickOutGame)
    {
        for (var i = 0; i < MaxWorldMapGimmickOutGame; i++)
        {
            if (!_worldMapGimmickOutGamesMaster[i].IsEnable())
            {
                _worldMapGimmickOutGamesMaster[i] = worldMapGimmickOutGame;
                return true;
            }
        }

        return false;
    }

    #endregion

    #region Fetch

    private int FetchGimmicksCache()
    {
        // Reset all gimmick cache entries
        var gimmickIndex = 0;
        int cacheCount;
        while (true)
        {
            if (gimmickIndex >= MaxGimmick)
            {
                gimmickIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickCache[gimmickIndex].Reset();

            gimmickIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (gimmickIndex >= MaxGimmick)
                return _gimmickCacheCount = cacheCount;

            var isEnabled = _gimmickMaster[gimmickIndex].IsEnable();
            if (isEnabled)
                _gimmickCache[cacheCount++] = _gimmickMaster[gimmickIndex];

            gimmickIndex++;
        }
    }

    private int FetchGimmickGroupsCache()
    {
        // Reset all cache entries
        var gimmickGroupIndex = 0;
        int cacheCount;
        while (true)
        {
            if (gimmickGroupIndex >= MaxGimmickGroup)
            {
                gimmickGroupIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickGroupCache[gimmickGroupIndex].Reset();

            gimmickGroupIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (gimmickGroupIndex >= MaxGimmickGroup)
                return _gimmickGroupCacheCount = cacheCount;

            var isEnabled = _gimmickGroupMaster[gimmickGroupIndex].IsEnable();
            if (isEnabled)
                _gimmickGroupCache[cacheCount++] = _gimmickGroupMaster[gimmickGroupIndex];

            gimmickGroupIndex++;
        }
    }

    private int FetchGimmickOrnamentsCache()
    {
        // Reset all cache entries
        var ornamentIndex = 0;
        int cacheCount;
        while (true)
        {
            if (ornamentIndex >= MaxGimmickOrnament)
            {
                ornamentIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickOrnamentsCache[ornamentIndex].Reset();

            ornamentIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (ornamentIndex >= MaxGimmickOrnament)
                return _gimmickOrnamentsCacheCount = cacheCount;

            var isEnabled = _gimmickOrnamentsMaster[ornamentIndex].IsEnable();
            if (isEnabled)
                _gimmickOrnamentsCache[cacheCount++] = _gimmickOrnamentsMaster[ornamentIndex];

            ornamentIndex++;
        }
    }

    private int FetchGimmickSequencesCache()
    {
        // Reset all cache entries
        var sequenceIndex = 0;
        int cacheCount;
        while (true)
        {
            if (sequenceIndex >= MaxGimmickSequence)
            {
                sequenceIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickSequencesCache[sequenceIndex].Reset();

            sequenceIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (sequenceIndex >= MaxGimmickSequence)
                return _gimmickSequencesCacheCount = cacheCount;

            var isEnabled = _gimmickSequencesMaster[sequenceIndex].IsEnable();
            if (isEnabled)
                _gimmickSequencesCache[cacheCount++] = _gimmickSequencesMaster[sequenceIndex];

            sequenceIndex++;
        }
    }

    private int FetchGimmickSequenceSchedulesCache()
    {
        // Reset all cache entries
        var scheduleIndex = 0;
        int cacheCount;
        while (true)
        {
            if (scheduleIndex >= MaxGimmickSequenceSchedule)
            {
                scheduleIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickSequenceScheduleCache[scheduleIndex].Reset();

            scheduleIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (scheduleIndex >= MaxGimmickSequenceSchedule)
                return _gimmickSequenceScheduleCacheCount = cacheCount;

            var isEnabled = _gimmickSequenceScheduleMaster[scheduleIndex].IsEnable();
            if (isEnabled)
                _gimmickSequenceScheduleCache[cacheCount++] = _gimmickSequenceScheduleMaster[scheduleIndex];

            scheduleIndex++;
        }
    }

    private int FetchGimmickIntervalsCache()
    {
        // Reset all cache entries
        var intervalIndex = 0;
        int cacheCount;
        while (true)
        {
            if (intervalIndex >= MaxGimmickInterval)
            {
                intervalIndex = 0;
                cacheCount = 0;
                break;
            }

            _gimmickIntervalCache[intervalIndex].Reset();

            intervalIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (intervalIndex >= MaxGimmickInterval)
                return _gimmickIntervalCacheCount = cacheCount;

            var isEnabled = _gimmickIntervalMaster[intervalIndex].IsEnable();
            if (isEnabled)
                _gimmickIntervalCache[cacheCount++] = _gimmickIntervalMaster[intervalIndex];

            intervalIndex++;
        }
    }

    private int FetchUserGimmick()
    {
        // Reset all cache entries
        var gimmickIndex = 0;
        int cacheCount;
        while (true)
        {
            if (gimmickIndex >= MaxUserGimmick)
            {
                gimmickIndex = 0;
                cacheCount = 0;
                break;
            }

            _userGimmickCache[gimmickIndex].Reset();

            gimmickIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (gimmickIndex >= MaxUserGimmick)
                return _userGimmickCacheCount = cacheCount;

            var isEnabled = _userGimmickMaster[gimmickIndex].IsEnable();
            if (isEnabled)
                _userGimmickCache[cacheCount++] = _userGimmickMaster[gimmickIndex];

            gimmickIndex++;
        }
    }

    private int FetchGimmickSequenceGroupsCache()
    {
        // Reset all cache entries
        var index = 0;
        int cacheCount;
        while (true)
        {
            if (index >= MaxGimmickSequenceGroup)
            {
                index = 0;
                cacheCount = 0;
                break;
            }

            _gimmickSequenceGroupsCache[index].Reset();

            index++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (index >= MaxGimmickSequenceGroup)
                return _gimmickSequenceGroupsCacheCount = cacheCount;

            var isEnabled = _gimmickSequenceGroupsMaster[index].IsEnable();
            if (isEnabled)
                _gimmickSequenceGroupsCache[cacheCount++] = _gimmickSequenceGroupsMaster[index];

            index++;
        }
    }

    private int FetchUserGimmickSequence()
    {
        // Reset all cache entries
        var sequenceIndex = 0;
        int cacheCount;
        while (true)
        {
            if (sequenceIndex >= MaxUserGimmickSequence)
            {
                sequenceIndex = 0;
                cacheCount = 0;
                break;
            }

            _userGimmickSequenceCache[sequenceIndex].Reset();

            sequenceIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (sequenceIndex >= MaxUserGimmickSequence)
                return _userGimmickSequenceCacheCount = cacheCount;

            var isEnabled = _userGimmickSequenceMaster[sequenceIndex].IsEnable();
            if (isEnabled)
                _userGimmickSequenceCache[cacheCount++] = _userGimmickSequenceMaster[sequenceIndex];

            sequenceIndex++;
        }
    }

    private int FetchUserGimmickOrnamentProgress()
    {
        // Reset all cache entries
        var progressIndex = 0;
        int cacheCount;
        while (true)
        {
            if (progressIndex >= MaxUserGimmickOrnamentProgress)
            {
                progressIndex = 0;
                cacheCount = 0;
                break;
            }

            _userGimmickOrnamentProgressCache[progressIndex].Reset();

            progressIndex++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (progressIndex >= MaxUserGimmickOrnamentProgress)
                return _userGimmickOrnamentProgressCacheCount = cacheCount;

            var isEnabled = _userGimmickOrnamentProgressMaster[progressIndex].IsEnable();
            if (isEnabled)
                _userGimmickOrnamentProgressCache[cacheCount++] = _userGimmickOrnamentProgressMaster[progressIndex];

            progressIndex++;
        }
    }

    private int FetchWorldMapGimmickOutGamesCache()
    {
        // Reset all cache entries
        var index = 0;
        int cacheCount;
        while (true)
        {
            if (index >= MaxWorldMapGimmickOutGame)
            {
                index = 0;
                cacheCount = 0;
                break;
            }

            _worldMapGimmickOutGamesCache[index].Reset();

            index++;
        }

        // Set master entries in current cache
        while (true)
        {
            if (index >= MaxWorldMapGimmickOutGame)
                return _worldMapGimmickOutGameCacheCount = cacheCount;

            var isEnabled = _worldMapGimmickOutGamesMaster[index].IsEnable();
            if (isEnabled)
                _worldMapGimmickOutGamesCache[cacheCount++] = _worldMapGimmickOutGamesMaster[index];

            index++;
        }
    }

    #endregion

    #region Get

    private void GetGimmickSequenceSchedule(int index, out GimmickSequenceSchedule gimmickSequenceSchedule)
    {
        gimmickSequenceSchedule = _gimmickSequenceScheduleCache[index];
    }

    private void GetGimmickSequence(int index, out GimmickSequence gimmickSequence)
    {
        gimmickSequence = _gimmickSequencesCache[index];
    }

    private void GetGimmickGroup(int index, out GimmickGroup gimmickGroup)
    {
        gimmickGroup = _gimmickGroupCache[index];
    }

    private void GetGimmick(int index, out Gimmick gimmick)
    {
        gimmick = _gimmickCache[index];
    }

    private void GetGimmickInterval(int index, out GimmickInterval gimmickInterval)
    {
        gimmickInterval = _gimmickIntervalCache[index];
    }

    private void GetGimmickOrnament(int index, out GimmickOrnament gimmickOrnament)
    {
        gimmickOrnament = _gimmickOrnamentsCache[index];
    }

    private void GetGimmickSequenceGroup(int index, out GimmickSequenceGroup gimmickSequenceGroup)
    {
        gimmickSequenceGroup = _gimmickSequenceGroupsCache[index];
    }

    private void GetUserGimmickOrnamentProgress(int index, out UserGimmickOrnamentProgress userGimmickOrnamentProgress)
    {
        userGimmickOrnamentProgress = _userGimmickOrnamentProgressCache[index];
    }

    private void GetUserGimmickSequence(int index, out UserGimmickSequence userGimmickSequence)
    {
        userGimmickSequence = _userGimmickSequenceCache[index];
    }

    private void GetUserGimmick(int index, out UserGimmick userGimmick)
    {
        userGimmick = _userGimmickCache[index];
    }

    public void GetWorldMapGimmickOutGame(int index, out WorldMapGimmickOutGame worldMapGimmickOutGame)
    {
        worldMapGimmickOutGame = _worldMapGimmickOutGamesCache[index];
    }

    public int GetWorldMapGimmickOutGamesCount()
    {
        return _worldMapGimmickOutGameCacheCount;
    }

    private WorldMapGimmickSequenceProgressType GetGimmickSequenceProgressType(long sequenceProgressRequireHour, long sequenceProgressStartDateTime)
    {
        var existRequireHour = IsExistProgressRequireHour(sequenceProgressRequireHour);
        var existStartDatetime = IsExistProgressStartDateTime(sequenceProgressStartDateTime);

        if (!existRequireHour)
            return existStartDatetime ? WorldMapGimmickSequenceProgressType.StartDateTimeOnly : WorldMapGimmickSequenceProgressType.None;

        return existStartDatetime ? WorldMapGimmickSequenceProgressType.RequireHourAndStartDateTime : WorldMapGimmickSequenceProgressType.RequireHourOnly;
    }

    private int GetNextGimmickSequenceId(int gimmickSequenceId)
    {
        var sequenceTable = DatabaseDefine.Master.EntityMGimmickSequenceTable;
        var sequenceGroupTable = DatabaseDefine.Master.EntityMGimmickSequenceGroupTable;

        if (sequenceTable.Count <= 0)
            return kInvalidId;

        var sequences = sequenceTable.All.Where(x => x.GimmickSequenceId == gimmickSequenceId);
        foreach (var sequence in sequences)
        {
            if (sequence.NextGimmickSequenceGroupId == kTerminalSequenceGroupId)
                return kTerminalSequenceId;

            var sequenceGroup = sequenceGroupTable.All.FirstOrDefault(x => sequence.NextGimmickSequenceGroupId == x.GimmickSequenceGroupId);
            if (sequenceGroup == null)
                continue;

            // HINT: Looking at the decompiled code, this should actually return kTerminalSequenceId, but that wouldn't make sense in this context
            return sequenceGroup.GimmickSequenceId;
        }

        return kInvalidId;
    }

    #endregion

    #region Reset

    private void ResetAll()
    {
        ResetGimmickOrnament();
        ResetGimmickSequenceGroup();
        ResetGimmickSequence();
        ResetGimmickSequenceRewardGroup();
        ResetGimmickSequenceSchedule();
        ResetGimmick();
        ResetGimmickGroup();
        ResetGimmickInterval();
        ResetEvaluateCondition();
        ResetEvaluateConditionValueGroup();
        ResetWorldMapGimmickOutGames();
        ResetGimmickOrnamentCages();
        ResetUserGimmick();
        ResetUserGimmickOrnamentProgress();
    }

    private void ResetGimmickOrnament()
    {
        for (var i = 0; i < MaxGimmickOrnament; i++)
        {
            _gimmickOrnamentsMaster[i].Reset();
            _gimmickOrnamentsCache[i].Reset();
        }
    }

    // RVA: 0x292D454 Offset: 0x292D454 VA: 0x292D454
    private void ResetGimmickSequenceGroup()
    {
        for (var i = 0; i < MaxGimmickSequenceGroup; i++)
        {
            _gimmickSequenceGroupsMaster[i].Reset();
            _gimmickSequenceGroupsCache[i].Reset();
        }
    }

    // RVA: 0x292D534 Offset: 0x292D534 VA: 0x292D534
    private void ResetGimmickSequence()
    {
        for (var i = 0; i < MaxGimmickSequence; i++)
        {
            _gimmickSequencesMaster[i].Reset();
            _gimmickSequencesCache[i].Reset();
        }
    }

    // RVA: 0x292D614 Offset: 0x292D614 VA: 0x292D614
    private void ResetGimmickSequenceRewardGroup()
    {
        for (var i = 0; i < MaxGimmickSequenceRewardGroup; i++)
        {
            _gimmickSequenceRewardGroupsMaster[i].Reset();
            _gimmickSequenceRewardGroupsCache[i].Reset();
        }
    }

    // RVA: 0x292D6F4 Offset: 0x292D6F4 VA: 0x292D6F4
    private void ResetGimmickSequenceSchedule()
    {
        for (var i = 0; i < MaxGimmickSequenceSchedule; i++)
        {
            _gimmickSequenceScheduleMaster[i].Reset();
            _gimmickSequenceScheduleCache[i].Reset();
        }
    }

    // RVA: 0x292D7D4 Offset: 0x292D7D4 VA: 0x292D7D4
    private void ResetGimmick()
    {
        for (var i = 0; i < MaxGimmick; i++)
        {
            _gimmickMaster[i].Reset();
            _gimmickCache[i].Reset();
        }
    }

    // RVA: 0x292D8B4 Offset: 0x292D8B4 VA: 0x292D8B4
    private void ResetGimmickGroup()
    {
        for (var i = 0; i < MaxGimmickGroup; i++)
        {
            _gimmickGroupMaster[i].Reset();
            _gimmickGroupCache[i].Reset();
        }
    }

    // RVA: 0x292D994 Offset: 0x292D994 VA: 0x292D994
    private void ResetGimmickInterval()
    {
        for (var i = 0; i < MaxGimmickInterval; i++)
        {
            _gimmickIntervalMaster[i].Reset();
            _gimmickIntervalCache[i].Reset();
        }
    }

    // RVA: 0x292DA74 Offset: 0x292DA74 VA: 0x292DA74
    private void ResetEvaluateCondition()
    {
        for (var i = 0; i < MaxEvaluateCondition; i++)
        {
            _evaluateConditionMaster[i].Reset();
            _evaluateConditionCache[i].Reset();
        }
    }

    // RVA: 0x292DB54 Offset: 0x292DB54 VA: 0x292DB54
    private void ResetEvaluateConditionValueGroup()
    {
        for (var i = 0; i < MaxEvaluateConditionValueGroup; i++)
        {
            _evaluateConditionValueGroupMaster[i].Reset();
            _evaluateConditionValueGroupCache[i].Reset();
        }
    }

    // RVA: 0x292DC34 Offset: 0x292DC34 VA: 0x292DC34
    private void ResetWorldMapGimmickOutGames()
    {
        for (var i = 0; i < MaxWorldMapGimmickOutGame; i++)
        {
            _worldMapGimmickOutGamesMaster[i].Reset();
            _worldMapGimmickOutGamesCache[i].Reset();
        }
    }

    // RVA: 0x292DD0C Offset: 0x292DD0C VA: 0x292DD0C
    private void ResetGimmickOrnamentCages()
    {
        for (var i = 0; i < MaxGimmickOrnamentCage; i++)
        {
            _gimmickOrnamentCagesMaster[i].Reset();
            _gimmickOrnamentCagesCache[i].Reset();
        }
    }

    // RVA: 0x292DDEC Offset: 0x292DDEC VA: 0x292DDEC
    private void ResetUserGimmick()
    {
        for (var i = 0; i < MaxUserGimmick; i++)
        {
            _userGimmickMaster[i].Reset();
            _userGimmickCache[i].Reset();
        }
    }

    // RVA: 0x292DEC4 Offset: 0x292DEC4 VA: 0x292DEC4
    private void ResetUserGimmickOrnamentProgress()
    {
        for (var i = 0; i < MaxUserGimmickOrnamentProgress; i++)
        {
            _userGimmickOrnamentProgressMaster[i].Reset();
            _userGimmickOrnamentProgressCache[i].Reset();
        }
    }

    private void ResetUserGimmickSequence()
    {
        for (var i = 0; i < MaxUserGimmickSequence; i++)
        {
            _userGimmickSequenceMaster[i].Reset();
            _userGimmickSequenceCache[i].Reset();
        }
    }

    #endregion

    private bool IsExistProgressRequireHour(long sequenceProgressRequireHour)
    {
        return sequenceProgressRequireHour != GimmickConstant.kInvalidSequenceProgressRequireHour;
    }

    private bool IsExistProgressStartDateTime(long sequenceProgressStartDateTime)
    {
        return sequenceProgressStartDateTime != GimmickConstant.kInvalidSequenceProgressStartDateTime;
    }
}
