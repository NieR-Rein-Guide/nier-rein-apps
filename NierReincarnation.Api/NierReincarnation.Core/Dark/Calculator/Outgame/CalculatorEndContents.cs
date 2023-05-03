using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System;
using System.Collections.Generic;
using static NierReincarnation.Core.Dark.View.UserInterface.Text.UserInterfaceTextKey;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorEndContents
    {
        public static readonly int kFirstAbilityReinforcedWeaponEvolutionOrder = 5;
        public static readonly int kSecondAbilityReinforcedWeaponEvolutionOrder = 8;
        public static readonly int kSkillReinforcedWeaponEvolutionOrder = 11; // 0x8
        private const int kFirstAcquisitionEndWeaponEvolutionOrder = 1;
        public static readonly int kFirstReleaseEndQuestEvolutionOrder = 4;
        public static readonly int kSecondReleaseEndQuestEvolutionOrder = 7;
        private const int kFinalReleaseEndQuestEvolutionOrder = 11;
        private const int kPlayEndStory2EvolutionOrder = 5;
        private const int kPlayEndStory3EvolutionOrder = 8;
        private const int kPlayEndStory4EvolutionOrder = 11;

        public static bool TryGetReleaseEndBossQuestText(int characterId, int weaponId, out string releaseQuestName)
        {
            if (CalculatorQuest.TryGetReleaseQuestNameFromAcquisitionWeaponId(weaponId, out releaseQuestName))
            {
                releaseQuestName = EndContents.kUnlockQuest.LocalizeWithParams(CalculatorCharacter.GetCharacterName(characterId), releaseQuestName);
                return true;
            }

            return false;
        }

        public static bool IsWeaponEvolutionStory(int storyId)
        {
            return GetEvolutionOrderFromStoryId(storyId) > kFirstAcquisitionEndWeaponEvolutionOrder;
        }

        //public static bool TryGetUnfinishedContentsStoryId(out int unfinishedStoryId)
        //{
        //    CalculatorWeapon.GetPossessionEndWeaponId(CalculatorStateUser.GetUserId());

        //    throw new NotImplementedException();
        //}

        //public static int[] GetRelatedContentsStoryIds(int firstEndWeaponId)
        //{
        //    CalculatorWeapon.GetEvolutionGroupWeaponId(CalculatorWeapon.GetWeaponEvolutionGroupId(firstEndWeaponId));

        //    throw new NotImplementedException();
        //}

        public static bool IsAlreadyViewStory(int contentsStoryId)
        {
            return DatabaseDefine.User.EntityIUserContentsStoryTable.TryFindByUserIdAndContentsStoryId((CalculatorStateUser.GetUserId(), contentsStoryId), out var _);
        }

        public static bool IsUnlockEndContents()
        {
            return DatabaseDefine.User.EntityIUserTutorialProgressTable.TryFindByUserIdAndTutorialType((CalculatorStateUser.GetUserId(), TutorialType.END_CONTENTS), out var _);
        }

        public static bool IsEndContentsQuestByEventChapterId(int eventChapterId)
        {
            var eventQuestChapter = DatabaseDefine.Master.EntityMEventQuestChapterTable.FindByEventQuestChapterId(eventChapterId);

            return eventQuestChapter?.EventQuestType == EventQuestType.END_CONTENTS;
        }

        private static bool TryGetContentsStoryId(int endWeaponId, out int contentsStoryId)
        {
            throw new NotImplementedException();
        }

        private static int GetEvolutionOrderFromStoryId(int storyId)
        {
            var constentsStory = DatabaseDefine.Master.EntityMContentsStoryTable.FindByContentsStoryId(storyId);

            throw new NotImplementedException();
        }

        private static int GetWeaponId(EntityMContentsStory entityMContentsStory)
        {
            if (entityMContentsStory.ContentsStoryUnlockConditionType == UnlockConditionType.QUEST_CLEAR)
            {
                return (int)CalculatorEvaluateCondition.GetEvaluateConditionValue(entityMContentsStory.UnlockEvaluateConditionId);
            }

            return (int)CalculatorEvaluateCondition.GetEvaluateConditionValue(CalculatorEvaluateCondition.kInvalidEvaluateConditionId);
        }

        private static bool TryGetEndContentsStoryId(int endWeaponId, out int resultStoryId)
        {
            resultStoryId = 0;
            foreach (var contentsStory in DatabaseDefine.Master.EntityMContentsStoryTable.All)
            {
                if (contentsStory.IsForcedPlay && GetWeaponId(contentsStory) == endWeaponId)
                {
                    var userContentsStory = DatabaseDefine.User.EntityIUserContentsStoryTable.FindByUserIdAndContentsStoryId((CalculatorStateUser.GetUserId(), contentsStory.ContentsStoryId));

                    if (userContentsStory != null)
                    {
                        return false;
                    }

                    resultStoryId = contentsStory.ContentsStoryId;
                    return true;
                }
            }

            return false;
        }

        private static bool TryGetEndContentsStoryId(int weaponEvolutionGroupId, int evolutionOrder, out int resultStoryId)
        {
            resultStoryId = 0;
            if (evolutionOrder != kFirstAcquisitionEndWeaponEvolutionOrder && evolutionOrder != kPlayEndStory2EvolutionOrder &&
                evolutionOrder != kPlayEndStory3EvolutionOrder && evolutionOrder != kPlayEndStory4EvolutionOrder)
            {
                return TryGetEndContentsStoryId(0, out resultStoryId);
            }

            return false;
        }
    }
}
