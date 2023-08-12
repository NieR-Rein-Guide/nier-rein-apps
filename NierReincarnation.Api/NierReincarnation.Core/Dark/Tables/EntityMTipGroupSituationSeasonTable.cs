using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMTipGroupSituationSeasonTable : TableBase<EntityMTipGroupSituationSeason>
{
    private readonly Func<EntityMTipGroupSituationSeason, (TipSituationType, int, int)> primaryIndexSelector;

    public EntityMTipGroupSituationSeasonTable(EntityMTipGroupSituationSeason[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.TipSituationType, element.TipSituationSeasonId, element.TipGroupId);
    }
}
