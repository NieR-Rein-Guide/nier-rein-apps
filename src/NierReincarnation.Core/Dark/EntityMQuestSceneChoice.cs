using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_scene_choice")]
public class EntityMQuestSceneChoice
{
    [Key(0)]
    public int MainFlowQuestSceneId { get; set; }

    [Key(1)]
    public QuestFlowType QuestFlowType { get; set; }

    [Key(2)]
    public int ChoiceNumber { get; set; }

    [Key(3)]
    public int QuestSceneChoiceEffectId { get; set; }
}
