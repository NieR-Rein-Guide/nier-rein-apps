using System;
using System.Collections.Generic;
using nier_rein_gui.Controls.Base;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests.Base
{
    abstract class ClosableQuestListPanel<T> : QuestListPanel<T>, IClosablePanel
    {
        public event EventHandler Closed;

        protected ClosableQuestListPanel(string name, IList<DifficultyType> difficulties) : base(name, difficulties)
        {
        }

        protected void OnClose()
        {
            Closed?.Invoke(this, new EventArgs());
        }
    }
}
