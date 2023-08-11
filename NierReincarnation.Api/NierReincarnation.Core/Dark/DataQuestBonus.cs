using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark;

public class DataQuestBonus
{
   
    public QuestBonusEquipType QuestBonusEquipType { get; }
   
    public int Id { get; }
   
    public int QuestBonusEffectGroupId { get; }

    public DataQuestBonus(QuestBonusEquipType questBonusEquipType, int id, int questBonusEffectGroupId)
    {
        QuestBonusEquipType = questBonusEquipType;
        Id = id;
        QuestBonusEffectGroupId = questBonusEffectGroupId;
    }
}
