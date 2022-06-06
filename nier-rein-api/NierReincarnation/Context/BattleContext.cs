namespace NierReincarnation.Context
{
    public class BattleContext
    {
        internal BattleContext() 
        { }

        public QuestBattleContext CreateQuestContext()
        {
            return new QuestBattleContext();
        }

        public BigHuntBattleContext CreateBigHuntContext()
        {
            return new BigHuntBattleContext();
        }

        public static bool HasRunningQuest()
        {
            // Check for event quest
            var result = QuestBattleContext.HasRunningEventQuest();
            if (result)
                return true;

            // Check for main quest
            result = QuestBattleContext.HasRunningMainQuest();
            if (result)
                return true;

            // Check for big hunt quest
            return BigHuntBattleContext.HasRunningBigHuntQuest();
        }
    }
}
