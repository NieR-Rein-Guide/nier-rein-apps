using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.Dark.Calculator.Database
{
    public static class CalculatorMasterData
    {
        public static EntityMSkillDetail GetEntityMSkillDetail(int skillId, int level)
        {
            var table = DatabaseDefine.Master.EntityMSkillTable;
            var skill = table.FindBySkillId(skillId);

            var table1 = DatabaseDefine.Master.EntityMSkillLevelGroupTable;
            var skillLevelGroup = table1.FindClosestBySkillLevelGroupIdAndLevelLowerLimit((skill.SkillLevelGroupId, level));
            if (skillLevelGroup == null)
                return null;

            var table2 = DatabaseDefine.Master.EntityMSkillDetailTable;
            return table2.FindBySkillDetailId(skillLevelGroup.SkillDetailId);
        }

        public static IReadOnlyList<EntityMCostumeAbilityGroup> GetEntityCostumeAbilityGroupList(int costumeAbilityGroupId)
        {
            var table = DatabaseDefine.Master.EntityMCostumeAbilityGroupTable;
            return table.FindByCostumeAbilityGroupId(costumeAbilityGroupId);
        }

        public static List<EntityMWeaponSkillGroup> GetEntityMWeaponSkillGroups(int skillGroupId)
        {
            var table = DatabaseDefine.Master.EntityMWeaponSkillGroupTable;
            var range = table.FindRangeByWeaponSkillGroupIdAndSlotNumber((skillGroupId, 0), (skillGroupId, int.MaxValue));

            return range.Where(x => x.WeaponSkillGroupId == skillGroupId).ToList();
        }

        public static List<EntityMWeaponAbilityGroup> GetEntityMWeaponAbilityGroupList(int abilityGroupId)
        {
            var table = DatabaseDefine.Master.EntityMWeaponAbilityGroupTable;
            var range = table.FindRangeByWeaponAbilityGroupIdAndSlotNumber((abilityGroupId, 0), (abilityGroupId, int.MaxValue));

            return range.Where(x => x.WeaponAbilityGroupId == abilityGroupId).ToList();
        }

        public static EntityMAbilityDetail GetEntityMAbilityDetail(int abilityId, int level)
        {
            var abilityTable = DatabaseDefine.Master.EntityMAbilityTable;
            var ability = abilityTable.FindByAbilityId(abilityId);

            var abilityLevelGroupTable = DatabaseDefine.Master.EntityMAbilityLevelGroupTable;
            var levelGroup = abilityLevelGroupTable.FindClosestByAbilityLevelGroupIdAndLevelLowerLimit((ability.AbilityLevelGroupId, level));

            if (levelGroup.AbilityLevelGroupId != ability.AbilityLevelGroupId)
                return null;

            return DatabaseDefine.Master.EntityMAbilityDetailTable.FindByAbilityDetailId(levelGroup.AbilityDetailId);
        }

        public static EntityMCostumeAbilityLevelGroup GetEntityMCostumeAbilityLevelGroup(int costumeAbilityLevelGroupId, int limitBreakCount)
        {
            var table = DatabaseDefine.Master.EntityMCostumeAbilityLevelGroupTable;
            var levelGroup = table.FindClosestByCostumeAbilityLevelGroupIdAndCostumeLimitBreakCountLowerLimit((costumeAbilityLevelGroupId, limitBreakCount));

            if (levelGroup.CostumeAbilityLevelGroupId != costumeAbilityLevelGroupId)
                return null;

            return levelGroup;
        }

        public static EntityMAbilityBehaviourGroup[] GetEntityMAbilityBehaviourGroups(int abilityBehaviourGroupId)
        {
            var table = DatabaseDefine.Master.EntityMAbilityBehaviourGroupTable;
            var range = table.FindRangeByAbilityBehaviourGroupIdAndAbilityBehaviourIndex((abilityBehaviourGroupId, 0), (abilityBehaviourGroupId, int.MaxValue));

            return range.Where(e => e.AbilityBehaviourGroupId == abilityBehaviourGroupId).ToArray();
        }

        public static RangeView<EntityMCharacterLevelBonusAbilityGroup> GetEntityMCharacterLevelBonusAbilityGroups(int groupId, int characterLevel)
        {
            var table = DatabaseDefine.Master.EntityMCharacterLevelBonusAbilityGroupTable;
            return table.FindRangeByCharacterLevelBonusAbilityGroupIdAndActivationCharacterLevel((groupId, 0), (groupId, characterLevel));
        }

        public static EntityMCharacterDisplaySwitch GetEntityMCharacterDisplaySwitch(int characterId)
        {
            var table = DatabaseDefine.Master.EntityMCharacterDisplaySwitchTable;
            return table.FindByCharacterId(characterId);
        }

        public static EntityMCharacter GetEntityMCharacter(int characterId)
        {
            var table = DatabaseDefine.Master.EntityMCharacterTable;
            return table.FindByCharacterId(characterId);
        }

        public static bool TryGetEntityMCharacterByEndWeaponId(int endWeaponId, out EntityMCharacter entityMCharacter)
        {
            var table = DatabaseDefine.Master.EntityMCharacterTable;
            var range = table.FindByEndWeaponId(endWeaponId);

            entityMCharacter = null;
            if (range.Count != 0)
                entityMCharacter = range[0];

            return range.Count != 0;
        }

        public static EntityMBattleRentalDeck GetEntityMBattleRentalDeck(int questId, QuestSceneType questSceneType)
        {
            var table = DatabaseDefine.Master.EntityMQuestSceneTable;
            var scene = table.All.FirstOrDefault(x => x.QuestId == questId && x.QuestSceneType == questSceneType);
            if (scene == null)
                return null;

            var table1 = DatabaseDefine.Master.EntityMQuestSceneBattleTable;
            var sceneBattle = table1.FindByQuestSceneId(scene.QuestSceneId);
            if (sceneBattle == null)
                return null;

            var table2 = DatabaseDefine.Master.EntityMBattleRentalDeckTable;
            return table2.FindByBattleGroupId(sceneBattle.BattleGroupId);
        }

        public static bool IsInTermQuestBonusCostume(EntityMQuestBonusCostumeSettingGroup entityMQuestBonusCostumeSettingGroup, long dateTime)
        {
            return IsInTermQuestBonus(entityMQuestBonusCostumeSettingGroup.QuestBonusTermGroupId, dateTime);
        }

        public static bool IsInTermQuestBonusCharacter(EntityMQuestBonusCharacterGroup entityMQuestBonusCharacterGroup, long dateTime)
        {
            return IsInTermQuestBonus(entityMQuestBonusCharacterGroup.QuestBonusTermGroupId, dateTime);
        }

        public static bool IsInTermQuestBonusWeapon(EntityMQuestBonusWeaponGroup entityMQuestBonusWeaponGroup, long dateTime)
        {
            return IsInTermQuestBonus(entityMQuestBonusWeaponGroup.QuestBonusTermGroupId, dateTime);
        }

        private static bool IsInTermQuestBonus(int questBonusTermGroupId, long dateTime)
        {
            if (questBonusTermGroupId == 0)
                return true;

            var table = DatabaseDefine.Master.EntityMQuestBonusTermGroupTable;
            var terms = table.FindByQuestBonusTermGroupId(questBonusTermGroupId);

            return terms.Any(t => CalculatorDateTime.IsWithinThePeriod(t.StartDatetime, t.EndDatetime, dateTime));
        }

        public static EntityMWeaponAwaken GetEntityWeaponAwaken(int weaponId)
        {
            var table = DatabaseDefine.Master.EntityMWeaponAwakenTable;
            return table.FindByWeaponId(weaponId);
        }
    }
}
