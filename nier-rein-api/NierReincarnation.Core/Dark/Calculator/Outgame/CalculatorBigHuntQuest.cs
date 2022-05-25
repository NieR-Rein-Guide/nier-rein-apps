namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorBigHuntQuest
    {
        public static long GetHighScoreByBigHuntBossId(long userId, int bigHuntBossId)
        {
            var table = DatabaseDefine.User.EntityIUserBigHuntMaxScoreTable;
            return table.FindByUserIdAndBigHuntBossId((userId, bigHuntBossId)).MaxScore;
        }
    }
}
