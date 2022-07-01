using NierReincarnation.Context;
using NierReincarnation.Core.Adam.Framework.Network;

namespace NierReincarnation
{
    public class NierReinContexts
    {
        //public DarkClient Client { get; } = new DarkClient();

        //public NotificationContext Notifications { get; } = new NotificationContext();

        //public GachaContext Gacha { get; }

        public BattleContext Battles { get; } = new BattleContext();

        //public QuestContext Quests { get; } = new QuestContext();

        public DeckContext Decks { get; } = new DeckContext();

        public AssetContext Assets { get; } = new AssetContext();
    }
}
