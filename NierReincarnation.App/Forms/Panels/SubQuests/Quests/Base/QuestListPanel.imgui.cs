﻿using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System.Collections.Generic;
using System.Numerics;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base
{
    internal abstract partial class QuestListPanel<TQuestData>
    {
        private NierButton difficultyButton;
        private StackLayout layout;
        private Label nameLabel;
        private List questList;

        private void InitializeComponent(string name, IList<DifficultyType> difficulties)
        {
            if (difficulties.Count > 1)
            {
                difficultyButton = new NierButton { Text = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)difficulties[0]).Localize(), Width = 100 };
            }

            questList = new List
            {
                ItemSpacing = 5,
                Size = Size.Parent
            };
            layout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    CreateHeaderLayout(name, difficultyButton),
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            questList
                        }
                    }
                }
            };

            InitializeComponent(layout);

            Content = layout;
        }

        protected virtual void InitializeComponent(StackLayout listLayout)
        { }

        protected abstract IQuest GetBaseQuest(TQuestData quest);

        protected abstract string GetQuestName(TQuestData quest);

        protected void UpdateQuestList(DifficultyType type)
        {
            questList.Items.Clear();

            var quests = GetQuestsByDifficulty(type);
            foreach (var quest in quests)
            {
                var baseQuest = GetBaseQuest(quest);

                var campaigns = CalculatorCampaign.CreateDataQuestCampaignAll(baseQuest);
                var stamCampaign = campaigns.TotalCampaignList.Find(x => x is DataQuestCampaign { QuestCampaignEffectType: QuestCampaignEffectType.STAMINA_CONSUME_AMOUNT });

                NierQuestButton btn = new()
                {
                    Padding = new Vector2(2, 2),
                    Width = 1f,
                    Text = GetQuestName(quest),
                    Stamina = baseQuest.EntityQuest.Stamina,
                    SuggestedPower = baseQuest.EntityQuest.RecommendedDeckPower,
                    IsClear = CalculatorQuest.IsClearQuest(baseQuest.QuestId, CalculatorStateUser.GetUserId()),
                    Enabled = !CalculatorQuest.IsQuestLocked(baseQuest.QuestId),
                    IsDaily = baseQuest.EntityQuest.DailyClearableCount > 0,
                    StaminaCampaign = stamCampaign as DataQuestCampaign,
                    Attribute = CalculatorQuest.GetFirstQuestDisplayAttributeType(baseQuest.EntityQuest.QuestDisplayAttributeGroupId)
                };
                btn.Clicked += async (s, e) =>
                {
                    await FightAsync(quests, quest);
                    UpdateQuestList(type);
                };

                questList.Items.Add(btn);
            }
        }

        protected void UpdateName(string name)
        {
            if (nameLabel != null)
            {
                nameLabel.Text = name;
            }
        }

        private StackLayout CreateHeaderLayout(string name, NierButton difficulty)
        {
            StackLayout result = new()
            {
                Alignment = Alignment.Horizontal,
                Size = Size.WidthAlign,
                ItemSpacing = 5
            };

            if (!string.IsNullOrEmpty(name))
            {
                nameLabel = new Label { Text = name, Font = FontResources.FotRodin(20) };
                result.Items.Add(new StackItem(nameLabel) { VerticalAlignment = VerticalAlignment.Center });
            }

            if (difficulty != null)
            {
                result.Items.Add(new StackItem(difficulty) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right });
            }

            return result;
        }
    }
}