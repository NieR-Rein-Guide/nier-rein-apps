using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.MasterMemory;
using NierReincarnation.Core.Subsystem.Serval;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCharacterRank
    {
        private const int InvalidAbilityDetailId = 0; // 0x0
        private const int kFirstCharacterRankExp = 0; // 0x4
        private const int kFirstCharacterRank = 1; // 0x8

        public static int GetCurrentRankExp(int characterId)
        {
            var character = DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((CalculatorStateUser.GetUserId(), characterId));

            return character != null
                ? GetExpOnSpecifiedRank(characterId, character.Level)
                : kFirstCharacterRankExp;
        }

        public static int GetCurrentMaxRankExp(int characterId)
        {
            var character = DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((CalculatorStateUser.GetUserId(), characterId));

            var currentRankExp = GetExpOnSpecifiedRank(characterId, character.Level);
            var nextRankExp = GetExpOnSpecifiedRank(characterId, character.Level + 1);

            return nextRankExp != 0
                ? nextRankExp - currentRankExp
                : nextRankExp;
        }

        public static int GetCharacterRank(int characterId)
        {
            var userId = CalculatorStateUser.GetUserId();
            var element = DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((userId, characterId));

            return GetCharacterRank(element);
        }

        private static int GetCharacterRank(EntityIUserCharacter character)
        {
            return character?.Level ?? kFirstCharacterRank;
        }

        public static int GetExpOnSpecifiedRank(int characterId, int rank)
        {
            var character = GetEntityMCharacter(characterId);

            return CalculatorCalculationSetting.GetNumericalParameter(character.RequiredExpForLevelUpNumericalParameterMapId, rank);
        }

        public static int GetCharacterMaxRank(int characterId)
        {
            var character = GetEntityMCharacter(characterId);
            var calcSetting = CalculatorCalculationSetting.CreateSimpleCalculationSetting(character.MaxLevelNumericalFunctionId);

            return CharacterServal.calcMaxLevel(calcSetting.FunctionType, calcSetting.FunctionParameters);
        }

        public static List<DataAbility> CreateCharacterRankAbilityList(long userId, int characterId)
        {
            var range = GetEntityMCharacterLevelBonusAbilityGroup(userId, characterId);
            return range.Select(x => CalculatorAbility.CreateDataAbility(x.AbilityId, x.AbilityLevel, 15)).ToList();
        }

        public static List<DataAbilityStatus> CreateCharacterRankAbilityStatusList(long userId, int characterId)
        {
            var result = new List<DataAbilityStatus>();

            var abilityGroups = GetEntityMCharacterLevelBonusAbilityGroup(userId, characterId);
            foreach (var abilityGroup in abilityGroups)
            {
                var ability = CalculatorAbility.CreateDataAbility(abilityGroup.AbilityId, abilityGroup.AbilityLevel, 15);
                result.AddRange(ability.AbilityStatusList);
            }

            return result;
        }

        private static RangeView<EntityMCharacterLevelBonusAbilityGroup> GetEntityMCharacterLevelBonusAbilityGroup(long userId, int characterId)
        {
            var character = GetEntityMCharacter(characterId);
            if (character == null)
                return RangeView<EntityMCharacterLevelBonusAbilityGroup>.Empty;

            var userCharacter = DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((userId, characterId));
            var rank = GetCharacterRank(userCharacter);

            return CalculatorMasterData.GetEntityMCharacterLevelBonusAbilityGroups(character.CharacterLevelBonusAbilityGroupId, rank);
        }

        public static void AggregateCharacterRankAbilities(long userId, int characterId, ref List<DataAbilityStatus> abilityStatusList, ref List<DataSkill> dataAbilityPassiveSkillList)
        {
            var characterLevelBonusAbilityGroups = GetEntityMCharacterLevelBonusAbilityGroup(userId, characterId);

            if (characterLevelBonusAbilityGroups.Count == 0) return;

            foreach (var characterLevelBonusAbilityGroup in characterLevelBonusAbilityGroups)
            {
                var ability = CalculatorAbility.CreateDataAbility(characterLevelBonusAbilityGroup.AbilityId, characterLevelBonusAbilityGroup.AbilityLevel, 0);

                abilityStatusList.AddRange(ability.AbilityStatusList);
                dataAbilityPassiveSkillList.AddRange(ability.PassiveSkillList);
            }
        }

        private static EntityMCharacter GetEntityMCharacter(int characterId) => DatabaseDefine.Master.EntityMCharacterTable.FindByCharacterId(characterId);
    }
}
