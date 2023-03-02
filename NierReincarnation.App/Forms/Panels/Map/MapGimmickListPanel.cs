using ImGui.Forms.Controls;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.View.UserInterface;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.Map
{
    internal partial class MapGimmickListPanel : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly MainQuestChapterData _chapter;

        private readonly List<WorldMapGimmickOutGame> _allGimmicks;

        public MapGimmickListPanel(NierReinContexts rein, MainQuestChapterData chapter)
        {
            _rein = rein;
            _chapter = chapter;

            _allGimmicks = new List<WorldMapGimmickOutGame>();

            InitializeComponent();

            UpdateChapterGimmicks(chapter.MainQuestChapterId);
            UpdateGimmicks(_allGimmicks);
        }

        private void UpdateChapterGimmicks(int chapterId)
        {
            CalculatorWorldMap.GenerateAllChapterGimmickDataAsync(chapterId, _allGimmicks);
        }
    }
}
