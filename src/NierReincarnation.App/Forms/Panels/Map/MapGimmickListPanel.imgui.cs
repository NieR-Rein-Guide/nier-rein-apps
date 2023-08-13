using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Resources;
using NierReincarnation.App.Support;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace NierReincarnation.App.Forms.Panels.Map
{
    internal partial class MapGimmickListPanel
    {
        private static readonly GimmickType[] TypeOrder =
        {
            GimmickType.CAGE_INTERVAL_DROP_ITEM,
            //GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM,
            GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT,
            GimmickType.CAGE_TREASURE_HUNT,
            GimmickType.MAP_ONLY_HIDE_OBELISK,
            //GimmickType.REPORT
        };

        private ZLayout mainLayout;

        private void InitializeComponent()
        {
            Content = mainLayout = new ZLayout
            {
                ItemSpacing = new Vector2(5, 5)
            };
        }

        private void UpdateGimmicks(List<WorldMapGimmickOutGame> allGimmicks)
        {
            mainLayout.Items.Clear();

            var typedGimmicks = allGimmicks.GroupBy(x => x.GimmickType).ToDictionary(x => x.Key, y => y.ToArray());
            foreach (var type in TypeOrder)
            {
                var gimmicks = typedGimmicks.ContainsKey(type) ? typedGimmicks[type] : Array.Empty<WorldMapGimmickOutGame>();
                mainLayout.Items.Add(CreateGimmickGroup(type, gimmicks));
            }
        }

        private StackLayout CreateGimmickGroup(GimmickType type, IList<WorldMapGimmickOutGame> gimmicks)
        {
            var groupLabel = new ImGui.Forms.Controls.Label { Text = GetGimmickTypeName(type) + $" ({gimmicks.Count})" };
            var gimmickList = new List { ItemSpacing = 5, Size = new Size(200, 200) };

            var unixNow = CalculatorDateTime.UnixTimeNow();
            foreach (var gimmick in gimmicks)
                gimmickList.Items.Add(CreateGimmickButton(gimmick, unixNow));

            var result = new StackLayout
            {
                Alignment = Alignment.Vertical,
                Size = Size.Content,
                Items =
                {
                    groupLabel,
                    gimmickList
                }
            };

            return result;
        }

        private NierButton CreateGimmickButton(WorldMapGimmickOutGame gimmick, long unixNow)
        {
            var isAvailable = CalculatorWorldMap.IsAvailableGimmick(gimmick, unixNow);
            var button = new NierButton
            {
                Enabled = isAvailable,
                Text = LocalizationResources.MapCollect
            };

            switch (gimmick.GimmickType)
            {
                case GimmickType.CAGE_INTERVAL_DROP_ITEM:
                    //case GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM:
                    button.Text += $" ({gimmick.GetAvailableIntervalGimmickCount(unixNow)}/{gimmick.MaxValue})";
                    button.Clicked += (s, e) => CollectButtonClick(button, gimmick);
                    break;

                case GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT:
                case GimmickType.CAGE_TREASURE_HUNT:
                    button.Clicked += (s, e) => CollectButtonClick(button, gimmick);
                    break;

                case GimmickType.MAP_ONLY_HIDE_OBELISK:
                    button.Clicked += (s, e) => ExecuteButtonClick(button, gimmick);
                    break;
            }

            return button;
        }

        private static string GetGimmickTypeName(GimmickType type)
        {
            return type switch
            {
                GimmickType.CAGE_INTERVAL_DROP_ITEM or GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM => LocalizationResources.MapLostItems,
                GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT => LocalizationResources.MapBlackBirds,
                GimmickType.CAGE_TREASURE_HUNT => LocalizationResources.MapFickleBlackBirds,
                GimmickType.REPORT => LocalizationResources.MapHiddenStories,
                GimmickType.CAGE_MEMORY => LocalizationResources.MapLostArchives,
                GimmickType.MAP_ONLY_HIDE_OBELISK => LocalizationResources.MapStrayScarecrows,
                _ => "Gimmick.Placeholder",
            };
        }

        #region Gimmick Button events

        private async void CollectButtonClick(NierButton sender, WorldMapGimmickOutGame gimmick)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            sender.Enabled = false;

            var rewards = await _rein.Gimmicks.Collect(gimmick);

            // Print rewards
            var rewardText = string.Join(Environment.NewLine, rewards.Select(x => CalculatorPossession.GetItemName(x.PossessionType, x.PossessionId) + " x" + x.Count));
            await MessageBox.ShowInformationAsync(LocalizationResources.MapCollected, rewardText);

            UpdateChapterGimmicks(_chapter.MainQuestChapterId);
            UpdateGimmicks(_allGimmicks);
        }

        private async void ExecuteButtonClick(NierButton sender, WorldMapGimmickOutGame gimmick)
        {
            sender.Enabled = false;

            var quest = CalculatorWorldMap.GetHideObeliskQuest(gimmick.GimmickId, gimmick.GimmickOrnamentIndex);
            var farmDlg = new HideObeliskFarmDialog(_rein, quest);
            await farmDlg.ShowAsync();

            UpdateChapterGimmicks(_chapter.MainQuestChapterId);
            UpdateGimmicks(_allGimmicks);
        }

        #endregion Gimmick Button events
    }
}
