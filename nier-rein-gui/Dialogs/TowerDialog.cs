﻿using System;
using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using ImGuiNET;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs
{
    class TowerDialog : Modal
    {
        private readonly QuestBattleContext _battleContext;
        private readonly IList<EventQuestData> _questList;

        private EventQuestData _quest;

        private ArrowButton previousButton;
        private ArrowButton nextButton;
        private Label captionLabel;
        private NierButton clearButton;

        private ComboBox<DataDeckInfo> decks;
        private List missionList;

        private bool _isWorking;

        public TowerDialog(NierReinContexts rein, IList<EventQuestData> questList, EventQuestData quest)
        {
            _battleContext = rein.Battles.CreateQuestContext();
            _questList = questList;
            _quest = quest;

            _battleContext.BeforeFinishWave += BattleContext_BeforeFinishWave;

            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            previousButton.Clicked += PreviousButton_Clicked;

            nextButton = new ArrowButton { Direction = ImGuiDir.Right };
            nextButton.Clicked += NextButton_Clicked;

            clearButton = new NierButton { Caption = LocalizationResources.Clear };
            clearButton.Clicked += ClearButton_Clicked;

            captionLabel = new Label { Caption = quest.QuestName };

            decks = new ComboBox<DataDeckInfo>();
            InitializeDecks(decks);

            missionList = new List();
            UpdateMissionList(missionList, _quest);

            Caption = LocalizationResources.AbyssTitle;
            Size = new Vector2(500, 150);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = ImGui.Forms.Models.Size.WidthAlign,
                        ItemSpacing = 5,
                        Items =
                        {
                            previousButton,
                            new StackItem(captionLabel){Size = ImGui.Forms.Models.Size.WidthAlign},
                            nextButton
                        }
                    },
                    new StackItem(decks){Size = ImGui.Forms.Models.Size.WidthAlign},
                    missionList,
                    new StackItem(clearButton){HorizontalAlignment = HorizontalAlignment.Right}
                }
            };
        }

        private async void ClearButton_Clicked(object sender, EventArgs e)
        {
            _isWorking = true;

            previousButton.Enabled = false;
            nextButton.Enabled = false;
            clearButton.Enabled = false;

            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.UserDeckNumber, DeckType.QUEST);
            await _battleContext.ExecuteEventQuest(_quest.Quest.ChapterId, _quest, deck);

            UpdateMissions(_quest);

            previousButton.Enabled = true;
            nextButton.Enabled = true;
            clearButton.Enabled = true;

            _isWorking = false;
        }

        private void BattleContext_BeforeFinishWave(object sender, NierReincarnation.Context.Models.Events.BeforeFinishWaveEventArgs e)
        {
            foreach (var mission in _quest.MissionData)
            {
                var masterMission = CalculatorQuest.GetEntityMQuestMission(mission.MissionId);
                switch (mission.QuestMissionConditionType)
                {
                    case QuestMissionConditionType.CRITICAL_COUNT_GE:
                        if (e.WaveNumber == 1)
                            e.BattleDetail.CriticalCount = masterMission.ConditionValue;
                        break;

                    case QuestMissionConditionType.COMBO_COUNT_GE:
                        if (e.WaveNumber == 1)
                            e.BattleDetail.ComboCount = masterMission.ConditionValue;
                        break;

                    case QuestMissionConditionType.MAX_DAMAGE:
                        if (e.WaveNumber == 1)
                            e.BattleDetail.MaxDamage = masterMission.ConditionValue;
                        break;
                }
            }
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            var start = _questList.IndexOf(_quest);
            for (var i = start + 1; i < start + _questList.Count; i++)
            {
                var quest = _questList[i % _questList.Count];
                if (CalculatorQuest.IsQuestLocked(quest.Quest.QuestId))
                    continue;

                _quest = quest;
                quest.IsLock = false;

                captionLabel.Caption = quest.QuestName;

                UpdateMissionList(missionList, quest);

                return;
            }
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            var start = _questList.IndexOf(_quest);
            for (var i = start - 1; i >= start - _questList.Count; i--)
            {
                var quest = _questList[i < 0 ? _questList.Count + i : i];
                if (CalculatorQuest.IsQuestLocked(quest.Quest.QuestId))
                    continue;

                _quest = quest;
                quest.IsLock = false;

                captionLabel.Caption = quest.QuestName;

                UpdateMissionList(missionList, quest);

                return;
            }
        }

        protected override bool ShouldCancelClose()
        {
            return _isWorking;
        }

        private void InitializeDecks(ComboBox<DataDeckInfo> decks)
        {
            decks.Items.Clear();

            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
                decks.Items.Add(new ComboBoxItem<DataDeckInfo>(deck));

            if (decks.Items.Count > 0)
                decks.SelectedItem = decks.Items[0];
        }

        private void UpdateMissionList(List missionList, EventQuestData quest)
        {
            missionList.Items.Clear();

            foreach (var mission in quest.MissionData)
                missionList.Items.Add(new CheckBox
                {
                    Enabled = false,
                    Checked = mission.IsClear,
                    Caption = mission.MissionTitle
                });
        }

        private void UpdateMissions(EventQuestData quest)
        {
            quest.MissionData = CalculatorQuest.GetMissionData(quest.Quest.QuestId);
            UpdateMissionList(missionList, quest);
        }
    }
}
