using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Forms;
using nier_rein_gui.Resources;
using nier_rein_gui.Support;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    class ClearAllMapItemsDialog : Modal
    {
        private readonly NierReinContexts _rein;
        private readonly IList<WorldMapGimmickOutGame> _gimmicks;
        private readonly IDictionary<(PossessionType, int), int> _rewardsDict = new Dictionary<(PossessionType, int), int>();

        private bool _isRunning;

        private Label countLabel;
        private Label limitLabel;
        private NierButton cancelBtn;
        private NierButton startBtn;
        private DataTable<(string, int)> rewards;

        public ClearAllMapItemsDialog(NierReinContexts rein)
        {
            _rein = rein;
            _gimmicks = EnumerateAvailableItemCollectGimmicks().ToArray();

            countLabel = new Label();
            limitLabel = new Label { TextColor = Color.Firebrick };
            startBtn = new NierButton { Text = LocalizationResources.Start };
            cancelBtn = new NierButton { Text = LocalizationResources.Cancel, Enabled = false };

            rewards = new DataTable<(string, int)>
            {
                IsSelectable = false,
                IsResizable = true,
                Columns =
                {
                    new DataTableColumn<(string, int)>(reward => reward.Item1, LocalizationResources.RewardsColumnName),
                    new DataTableColumn<(string, int)>(reward => $"{reward.Item2}", LocalizationResources.RewardsColumnCount)
                }
            };

            Caption = LocalizationResources.TitleAllMapItems;
            Size = new Vector2(270, 200);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    null,
                    null,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Size = ImGui.Forms.Models.Size.Content,
                        Items =
                        {
                            new StackItem(cancelBtn){Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right},
                            new StackItem(startBtn){HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    },
                    rewards
                }
            };

            startBtn.Clicked += StartBtn_Clicked;
            cancelBtn.Clicked += CancelBtn_Clicked;

            if (CooldownTimer.IsRunning)
            {
                SetLimitLabelText(CooldownTimer.CurrentCooldown);
                SetLimitLabel(limitLabel);
            }

            CooldownTimer.CooldownStart += CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish += CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
        }

        protected override Task CloseInternal()
        {
            CooldownTimer.CooldownStart -= CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish -= CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed -= CooldownTimer_Elapsed;

            return Task.CompletedTask;
        }

        #region Cooldown events

        private void CooldownTimer_Elapsed(object sender, TimeSpan e)
        {
            SetLimitLabelText(e);
        }

        private void CooldownTimer_CooldownFinish(object sender, EventArgs e)
        {
            SetLimitLabelText(TimeSpan.Zero);
            SetLimitLabel(null);
        }

        private void CooldownTimer_CooldownStart(object sender, TimeSpan e)
        {
            SetLimitLabelText(e);
            SetLimitLabel(limitLabel);
        }

        private void SetLimitLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[0] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[0] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetLimitLabelText(TimeSpan time)
        {
            limitLabel.Text = string.Format(LocalizationResources.LimitTimer, time);
        }

        #endregion

        #region Enumerate methods

        public static bool HasCollectableGimmicks()
        {
            return EnumerateAvailableItemCollectGimmicks().Any();
        }

        public static IEnumerable<WorldMapGimmickOutGame> EnumerateAvailableItemCollectGimmicks()
        {
            return EnumerateAvailableGimmicks().Where(x =>
                x.GimmickType == GimmickType.CAGE_INTERVAL_DROP_ITEM ||
                x.GimmickType == GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM);
        }

        private static IEnumerable<WorldMapGimmickOutGame> EnumerateAvailableGimmicks()
        {
            foreach (var season in CalculatorQuest.GetMainQuestSeasons())
                foreach (var chapter in CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId))
                {
                    foreach (var gimmick in CalculatorWorldMap.EnumerateChapterGimmickDataAsync(chapter.MainQuestChapterId))
                        yield return gimmick;
                }
        }

        #endregion

        protected override bool ShouldCancelClose()
        {
            return _isRunning;
        }

        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            startBtn.Enabled = false;
            cancelBtn.Enabled = true;
            _isRunning = true;

            SetCountLabel(countLabel);
            SetCountLabelText(0);

            var gimmickContext = _rein.Gimmicks;

            var didAll = _gimmicks.Count == 0;
            for (var i = 0; i < _gimmicks.Count; i++)
            {
                if (!_isRunning)
                    break;

                SetCountLabelText(i);
                var rewards = await gimmickContext.Collect(_gimmicks[i]);

                (Application.Instance.MainForm as MainForm).UpdateUser();
                (Application.Instance.MainForm as MainForm).UpdateStamina();

                AddRewards(rewards);

                didAll = i + 1 == _gimmicks.Count;
            }

            if (didAll)
                SetCountLabelText(_gimmicks.Count);

            startBtn.Enabled = !didAll;
            cancelBtn.Enabled = false;
            _isRunning = false;

            if (didAll)
                Result = DialogResult.Ok;
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            _isRunning = false;
        }

        private void AddRewards(IList<GimmickReward> gimmickRewards)
        {
            foreach (var drop in gimmickRewards)
            {
                if (!_rewardsDict.TryGetValue((drop.PossessionType, drop.PossessionId), out var count))
                    count = 0;

                _rewardsDict[(drop.PossessionType, drop.PossessionId)] = count + drop.Count;
            }

            rewards.Rows.Clear();
            foreach (var reward in _rewardsDict)
                rewards.Rows.Add(new DataTableRow<(string, int)>((GetItemText(reward.Key), reward.Value)));
        }

        private void SetCountLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[1] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetCountLabelText(int count)
        {
            countLabel.Text = string.Format(LocalizationResources.CollectItemsHeader, count, _gimmicks.Count);
        }

        private string GetItemText((PossessionType,int) reward)
        {
            return CalculatorPossession.GetItemName(reward.Item1, reward.Item2);
        }
    }
}
