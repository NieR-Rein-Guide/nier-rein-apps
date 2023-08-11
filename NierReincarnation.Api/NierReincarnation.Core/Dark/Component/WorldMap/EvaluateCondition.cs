namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct EvaluateCondition
{
    public int EvaluateConditionId { get; set; }

    public void Reset()
    {
        EvaluateConditionId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return EvaluateConditionId != GimmickConstant.kInvalidId;
    }
}
