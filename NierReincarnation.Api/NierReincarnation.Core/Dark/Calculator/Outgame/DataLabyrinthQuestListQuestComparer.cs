using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public sealed class DataLabyrinthQuestListQuestComparer : IComparer<DataLabyrinthQuestListQuest>
    {
        // Fields
        public static readonly DataLabyrinthQuestListQuestComparer InstanceAscending = new DataLabyrinthQuestListQuestComparer(true);
        public static readonly DataLabyrinthQuestListQuestComparer InstanceDescending = new DataLabyrinthQuestListQuestComparer(false);
        private readonly bool _ascending;

        // Methods

        // RVA: 0x28F1918 Offset: 0x28F1918 VA: 0x28F1918
        private DataLabyrinthQuestListQuestComparer(bool ascending)
        {
            _ascending = ascending;
        }

        // RVA: 0x28F1948 Offset: 0x28F1948 VA: 0x28F1948 Slot: 4
        public int Compare(DataLabyrinthQuestListQuest x, DataLabyrinthQuestListQuest y)
        {
            if (!_ascending)
            {
                if (y != null && x != null)
                    return y.QuestSortOrder - x.QuestSortOrder;
            }
            else
            {
                if (x != null && y != null)
                    return x.QuestSortOrder - y.QuestSortOrder;
            }

            throw new ArgumentNullException();
        }
    }
}
