using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;

namespace nier_rein_gui.Forms.Panels.SubQuests
{
    partial class BigHuntPanel
    {
        private ActivableList bossList;
        private List questList;

        private void InitializeComponent()
        {
            bossList = new ActivableList { ItemSpacing = 5 };
            questList = new List { ItemSpacing = 5 };

            Content = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Items =
                {
                    new StackItem(bossList){Size = new Size(.35f,1f)},
                    new StackItem(questList){Size = new Size(.65f,1f)}
                }
            };
        }

        private void SetBossQuestList()
        {
            bossList.Items.Clear();

            foreach (var chapter in GetBossQuests())
            {
                bossList.Items.Add(new NierButton
                {
                    Width = 1f,
                    Text = chapter.BossQuestName,
                    IsClickActive = true
                });
            }
        }

        private void SetQuestList(int bossIndex)
        {
            questList.Items.Clear();

            foreach (var quest in GetQuests(bossIndex))
            {
                questList.Items.Add(new NierButton
                {
                    Width = 1f,
                    Text = quest.QuestName,
                    Enabled = !quest.IsLock
                });
            }
        }
    }
}
