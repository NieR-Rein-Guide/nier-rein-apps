namespace NierReincarnation.Core.Dark.Component.WorldMap;

public struct EvaluateConditionValueGroup
{
    public int EvaluateConditionValueGroupId { get; set; }

    public void Reset()
    {
        EvaluateConditionValueGroupId = GimmickConstant.kInvalidId;
    }

    public bool IsEnable()
    {
        return EvaluateConditionValueGroupId != GimmickConstant.kInvalidId;
    }
}
