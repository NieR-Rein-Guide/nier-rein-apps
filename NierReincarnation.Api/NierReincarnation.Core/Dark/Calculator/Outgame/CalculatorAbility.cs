using System.Collections.Generic;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorAbility
    {
        public static int MIN_LEVEL = 1;
        public static int MAX_LEVEL = 15;
        private static readonly int kInvalidAbilityId = 0;
        //private static readonly int kStringCapacity;
        //private static readonly ArtStringBuilder ArtStringBuilder;

        public static DataAbility CreateDataAbility(int abilityId, int slotNumber, int level, int levelMax)
        {
            var ability = CreateDataAbility(abilityId, level, levelMax);
            ability.SlotNumber = slotNumber;

            return ability;
        }

        public static DataAbility CreateDataAbility(int abilityId, int level, int levelMax)
        {
            if (abilityId == 0)
                return null;

            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityId, level);
            if (abilityDetail == null)
                return null;

            var status = new List<DataAbilityStatus>();
            var skills = new List<DataSkill>();
            CreateDataAbilityBehaviours(abilityDetail.AbilityBehaviourGroupId, status, skills);

            return new DataAbility
            {
                AbilityId = abilityId,
                AbilityName = GetName(abilityDetail.NameAbilityTextId),
                AbilityDescriptionText = GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                AbilityLevel = level,
                AbilityMaxLevel = levelMax,
                AbilityCategoryId = abilityDetail.AssetCategoryId,
                AbilityVariationId = abilityDetail.AssetVariationId,
                IsLocked = level == 0,
                AbilityStatusList = status,
                PassiveSkillList = skills
            };
        }

        public static void CreateDataAbilityBehaviours(int abilityBehaviourGroupId, List<DataAbilityStatus> abilityStatusList, List<DataSkill> abilitySkillList)
        {
            abilityStatusList.Clear();

            var groups = CalculatorMasterData.GetEntityMAbilityBehaviourGroups(abilityBehaviourGroupId);
            foreach (var group in groups)
            {
                var behaviour = GetEntityMAbilityBehaviour(group.AbilityBehaviourId);
                switch (behaviour.AbilityBehaviourType)
                {
                    case AbilityBehaviourType.PASSIVE_SKILL:
                        CreateDataAbilitySkill(behaviour, abilitySkillList);
                        break;

                    case AbilityBehaviourType.STATUS:
                        CreateDataAbilityStatus(behaviour, abilityStatusList);
                        break;
                }
            }
        }

        private static EntityMAbilityBehaviour GetEntityMAbilityBehaviour(int abilityBehaviourId)
        {
            var table = DatabaseDefine.Master.EntityMAbilityBehaviourTable;
            return table.FindByAbilityBehaviourId(abilityBehaviourId);
        }

        private static void CreateDataAbilityStatus(EntityMAbilityBehaviour abilityBehaviour, List<DataAbilityStatus> abilityStatusList)
        {
            var actionId = abilityBehaviour.AbilityBehaviourActionId;
            var actionStatus = GetEntityMAbilityBehaviourActionStatus(actionId);
            var status = GetEntityMAbilityStatus(actionStatus.AbilityStatusId);

            var abilityStatus = new DataAbilityStatus
            {
                AttributeConditionType = actionStatus.AttributeConditionType,
                ApplyScopeType = actionStatus.ApplyScopeType,
                AbilityBehaviourStatusChangeType = actionStatus.AbilityBehaviourStatusChangeType,
                OrganizationConditionType = actionStatus.AbilityOrganizationConditionType
            };

            CreateAbilityBehaviourStatusChangeValueDic(status, abilityStatus);
            abilityStatusList.Add(abilityStatus);
        }

        private static EntityMAbilityBehaviourActionStatus GetEntityMAbilityBehaviourActionStatus(int abilityBehaviourActionId)
        {
            var table = DatabaseDefine.Master.EntityMAbilityBehaviourActionStatusTable;
            return table.FindByAbilityBehaviourActionId(abilityBehaviourActionId);
        }

        private static EntityMAbilityStatus GetEntityMAbilityStatus(int abilityStatusId)
        {
            var table = DatabaseDefine.Master.EntityMAbilityStatusTable;
            return table.FindByAbilityStatusId(abilityStatusId);
        }

        private static void CreateAbilityBehaviourStatusChangeValueDic(EntityMAbilityStatus abilityStatus, DataAbilityStatus dataAbilityStatus)
        {
            var statusValue = new StatusValue(abilityStatus.Agility, abilityStatus.Attack, abilityStatus.CriticalAttackRatioPermil, abilityStatus.CriticalRatioPermil, abilityStatus.EvasionRatioPermil, abilityStatus.Hp, abilityStatus.Vitality);
            dataAbilityStatus.StatusChangeValue = statusValue;
        }

        private static void CreateDataAbilitySkill(EntityMAbilityBehaviour abilityBehaviour, List<DataSkill> abilitySkillList)
        {
            var passiveSkill = GetEntityMAbilityBehaviourActionPassiveSkill(abilityBehaviour.AbilityBehaviourActionId);
            var abilitySkill = CalculatorSkill.CreateDataAbilitySkill(passiveSkill.SkillDetailId);

            abilitySkillList.Add(abilitySkill);
        }

        private static EntityMAbilityBehaviourActionPassiveSkill GetEntityMAbilityBehaviourActionPassiveSkill(int abilityBehaviourActionId)
        {
            var table = DatabaseDefine.Master.EntityMAbilityBehaviourActionPassiveSkillTable;
            return table.FindByAbilityBehaviourActionId(abilityBehaviourActionId);
        }

        public static string GetName(int nameTextId)
        {
            return string.Format(UserInterfaceTextKey.Ability.kName, nameTextId).Localize();
        }

        public static string GetDescriptionLong(int descriptionTextId)
        {
            return string.Format(UserInterfaceTextKey.Ability.kDescriptionLong, descriptionTextId).Localize();
        }

        public static string GetDescriptionLongByAbilityId(int abilityId, int level)
        {
            var masterAbility = CalculatorMasterData.GetEntityMAbilityDetail(abilityId, level);
            if (masterAbility == null)
                return null;

            return GetDescriptionLong(masterAbility.DescriptionAbilityTextId);
        }
    }
}
