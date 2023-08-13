using NierReincarnation.App.Controls.Base;
using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base
{
    internal abstract class ClosableQuestListPanel<T> : QuestListPanel<T>, IClosablePanel
    {
        public event EventHandler Closed;

        protected ClosableQuestListPanel(string name, IList<DifficultyType> difficulties) : base(name, difficulties)
        {
        }

        protected void OnClose()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
