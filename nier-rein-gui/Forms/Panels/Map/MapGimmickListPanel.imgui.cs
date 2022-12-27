using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs.FarmDialogs;
using nier_rein_gui.Resources;
using nier_rein_gui.Support;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.Panels.Map
{
    partial class MapGimmickListPanel
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
            var groupLabel = new ImGui.Forms.Controls.Label { Caption = GetGimmickTypeName(type) + $" ({gimmicks.Count})" };
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
                Caption = LocalizationResources.MapCollect
            };

            switch (gimmick.GimmickType)
            {
                case GimmickType.CAGE_INTERVAL_DROP_ITEM:
                    //case GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM:
                    button.Caption += $" ({gimmick.GetAvailableIntervalGimmickCount(unixNow)}/{gimmick.MaxValue})";
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

        private string GetGimmickTypeName(GimmickType type)
        {
            switch (type)
            {
                case GimmickType.CAGE_INTERVAL_DROP_ITEM:
                case GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM:
                    return LocalizationResources.MapLostItems;

                case GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT:
                    return LocalizationResources.MapBlackBirds;

                case GimmickType.CAGE_TREASURE_HUNT:
                    return LocalizationResources.MapFickleBlackBirds;

                case GimmickType.REPORT:
                    return LocalizationResources.MapHiddenStories;

                case GimmickType.CAGE_MEMORY:
                    return LocalizationResources.MapLostArchives;

                case GimmickType.MAP_ONLY_HIDE_OBELISK:
                    return LocalizationResources.MapStrayScarecrows;

                default:
                    return "Gimmick.Placeholder";
            }
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

        #endregion
    }
}
