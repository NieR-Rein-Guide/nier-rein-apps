using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportSubjugationMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var challenge in MasterDb.EntityMBigHuntBossQuestGroupChallengeCategoryTable.All.OrderBy(x => x.SortOrder))
        {
            var bossQuestGroups = MasterDb.EntityMBigHuntBossQuestGroupTable.All
                .Where(x => x.BigHuntBossQuestGroupId == challenge.BigHuntBossQuestGroupId)
                .OrderBy(x => x.SortOrder);

            foreach (var bossQuestGroup in bossQuestGroups)
            {
                var bossQuest = MasterDb.EntityMBigHuntBossQuestTable.FindByBigHuntBossQuestId(bossQuestGroup.BigHuntBossQuestId);
                //var rewardGroupSchedule = bossQuest.BigHuntScoreRewardGroupScheduleId; // reward structure, latest from 2022/02

                var boss = MasterDb.EntityMBigHuntBossTable.FindByBigHuntBossId(bossQuest.BigHuntBossId);
                var bossName = string.Format(UserInterfaceTextKey.BigHunt.kBossNameFormat, boss.NameBigHuntBossTextId).Localize();
                //var bossGradeGroup = _db.EntityMBigHuntBossGradeGroupTable.All.Where(x => x.BigHuntBossGradeGroupId == boss.BigHuntBossGradeGroupId).OrderBy(x => x.NecessaryScore); // scores + requirements

                var questGroups = MasterDb.EntityMBigHuntQuestGroupTable.All
                    .Where(x => x.BigHuntQuestGroupId == bossQuest.BigHuntQuestGroupId)
                    .OrderBy(x => x.SortOrder);

                Console.WriteLine($"{bossName} ({boss.AttributeType.ToFormattedStr()}) {(bossQuest.DailyChallengeCount > 1 ? $"x{bossQuest.DailyChallengeCount} daily" : "")}");

                foreach (var questGroup in questGroups)
                {
                    var quest = MasterDb.EntityMBigHuntQuestTable.FindByBigHuntQuestId(questGroup.BigHuntQuestId);
                    var questName = string.Format(UserInterfaceTextKey.Quest.kBossName, quest.QuestId).Localize();
                    MasterDb.EntityMQuestTable.TryFindByQuestId(quest.QuestId, out var quest2);
                    var questName2 = string.Format(UserInterfaceTextKey.Quest.kQuestNameTextKey, quest2.NameQuestTextId).Localize();
                    var questScoreCoefficient = MasterDb.EntityMBigHuntQuestScoreCoefficientTable.FindByBigHuntQuestScoreCoefficientId(quest.BigHuntQuestScoreCoefficientId);

                    var questScene = MasterDb.EntityMQuestSceneTable.All.FirstOrDefault(x => x.QuestId == quest2.QuestId);
                    var questSceneBattle = MasterDb.EntityMQuestSceneBattleTable.FindByQuestSceneId(questScene.QuestSceneId);
                    var battle = MasterDb.EntityMBattleBigHuntTable.FindByBattleGroupId(questSceneBattle.BattleGroupId);

                    Console.WriteLine($"- {questName} {questName2} ({quest2.RecommendedDeckPower}) - {questScoreCoefficient.ScoreDifficultBonusPermil / 10}%");

                    //var battleKdGaugeGroups = Db.EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable.All
                    //    .Where(x => x.KnockDownGaugeValueConfigGroupId == battle.KnockDownGaugeValueConfigGroupId)
                    //    .GroupBy(x => x.ActiveSkillHitCount);
                    //foreach (var battleKdGaugeGroup in battleKdGaugeGroups)
                    //{
                    //    Console.WriteLine($"-- {battleKdGaugeGroup.Key}-hit skill");

                    //    foreach (var battleKdGauge in battleKdGaugeGroup.OrderBy(x => x.GaugeValueLowerLimit))
                    //    {
                    //        Console.WriteLine($"--- DMG Lower Limit: {battleKdGauge.DamageValueLowerLimit} | Gauge Lower Limit: {battleKdGauge.GaugeValueLowerLimit} | Correction Ratio: {battleKdGauge.CorrectionRatioPermil}");
                    //    }
                    //}

                    //int wave = 1;
                    //var battlePhaseGroups = Db.EntityMBattleBigHuntPhaseGroupTable.All.Where(x => x.BattleBigHuntPhaseGroupId == battle.BattleBigHuntPhaseGroupId).OrderBy(x => x.BattleBigHuntPhaseGroupOrder);
                    //foreach (var battlePhaseGroup in battlePhaseGroups)
                    //{
                    //    Console.WriteLine($"-- Wave {wave++} ({battlePhaseGroup.NormalPhaseFrameCount / 30}sec)");
                    //    var battleDamageThresholdGroups = Db.EntityMBattleBigHuntDamageThresholdGroupTable.All
                    //        .Where(x => x.KnockDownDamageThresholdGroupId == battlePhaseGroup.KnockDownDamageThresholdGroupId)
                    //        .OrderBy(x => x.KnockDownDamageThresholdGroupOrder);

                    //    foreach (var battleDamageThresholdGroup in battleDamageThresholdGroups)
                    //    {
                    //        if (battleDamageThresholdGroup.IsKnockDown)
                    //        {
                    //            Console.WriteLine("--- KD: Yes | " +
                    //                $"DMG Threshold: {battleDamageThresholdGroup.KnockDownCumulativeDamageThreshold} | " +
                    //                $"Damage Ratio: {battleDamageThresholdGroup.DamageRatio / 10}% | "
                    //                $"Duration: {battleDamageThresholdGroup.KnockDownDurationFrameCount / 30}sec");
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine($"--- KD: No  | DMG Threshold: {battleDamageThresholdGroup.KnockDownCumulativeDamageThreshold}");
                    //        }
                    //    }
                    //}
                }
                Console.WriteLine();
            }
        }

        return Task.CompletedTask;
    }
}
