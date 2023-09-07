using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionRecoveryPointCorrectionTable : TableBase<EntityMSkillBehaviourActionRecoveryPointCorrection>
{
    private readonly Func<EntityMSkillBehaviourActionRecoveryPointCorrection, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionRecoveryPointCorrectionTable(EntityMSkillBehaviourActionRecoveryPointCorrection[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }
}
