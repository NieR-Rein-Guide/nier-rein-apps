using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable : TableBase<EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable(EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
