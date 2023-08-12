using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark;

public class QuestMissionData
{
    public int MissionId { get; set; }

    public string MissionTitle { get; set; }

    public bool IsClear { get; set; }

    public QuestMissionConditionType QuestMissionConditionType { get; set; }
}
