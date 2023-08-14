using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeDefaultSkillLotteryGroupTable : TableBase<EntityMCostumeDefaultSkillLotteryGroup>
{
    private readonly Func<EntityMCostumeDefaultSkillLotteryGroup, (int, int)> primaryIndexSelector;

    public EntityMCostumeDefaultSkillLotteryGroupTable(EntityMCostumeDefaultSkillLotteryGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeDefaultSkillLotteryGroupId, element.SkillDetailId);
    }

    public RangeView<EntityMCostumeDefaultSkillLotteryGroup> FindRangeByCostumeDefaultSkillLotteryGroupIdAndSkillDetailId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
