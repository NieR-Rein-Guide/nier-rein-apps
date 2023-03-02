﻿using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public sealed class DataLabyrinthQuestListStageComparer : IComparer<DataLabyrinthQuestListStage>
    {
        // Fields
        public static readonly DataLabyrinthQuestListStageComparer InstanceAscending=new DataLabyrinthQuestListStageComparer(true); // 0x0
        public static readonly DataLabyrinthQuestListStageComparer InstanceDescending=new DataLabyrinthQuestListStageComparer(false); // 0x8
        private readonly bool _ascending; // 0x10

        // Methods

        // RVA: 0x28F1A20 Offset: 0x28F1A20 VA: 0x28F1A20
        private DataLabyrinthQuestListStageComparer(bool ascending)
        {
            _ascending = ascending;
        }

        // RVA: 0x28F1A50 Offset: 0x28F1A50 VA: 0x28F1A50 Slot: 4
        public int Compare(DataLabyrinthQuestListStage x, DataLabyrinthQuestListStage y)
        {
            if (!_ascending)
            {
                if (y != null && x != null)
                    return y.StageSortOrder - x.StageSortOrder;
            }
            else
            {
                if (x != null && y != null)
                    return x.StageSortOrder - y.StageSortOrder;
            }

            throw new ArgumentNullException();
        }
    }
}