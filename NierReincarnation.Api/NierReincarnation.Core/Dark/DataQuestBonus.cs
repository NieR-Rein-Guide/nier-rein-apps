using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark
{
    public class DataQuestBonus
    {
        // 0x10
        public QuestBonusEquipType QuestBonusEquipType { get; }
        // 0x14
        public int Id { get; }
        // 0x18
        public int QuestBonusEffectGroupId { get; }

        public DataQuestBonus(QuestBonusEquipType questBonusEquipType, int id, int questBonusEffectGroupId)
        {
            QuestBonusEquipType = questBonusEquipType;
            Id = id;
            QuestBonusEffectGroupId = questBonusEffectGroupId;
        }
    }
}
