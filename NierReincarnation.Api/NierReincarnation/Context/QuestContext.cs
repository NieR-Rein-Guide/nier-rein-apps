using Google.Protobuf.WellKnownTypes;
using NierReincarnation.Core.Adam.Framework.Network;
using System.Threading.Tasks;

namespace NierReincarnation.Context;

public class QuestContext : BaseContext
{
    private readonly DarkClient _dc;

    internal QuestContext()
    {
        _dc = new DarkClient();
    }

    public Task ReceiveDailyRewards()
    {
        return TryRequest(() => _dc.QuestService.ReceiveDailyQuestGroupCompleteRewardAsync(new Empty()));
    }
}
