using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct GimmickSequence
{
    public int GimmickSequenceId { get; set; }
    public int NextGimmickSequenceGroupId  { get; set; }
    public int GimmickGroupId  { get; set; }
    public long ProgressRequireHour  { get; set; }
    public long ProgressStartDatetime  { get; set; }
    public FlowType FlowType  { get; set; }

    public void Reset()
    {
        GimmickSequenceId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return GimmickSequenceId != GimmickConstant.kInvalidId;
    }
	}
