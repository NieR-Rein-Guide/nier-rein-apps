﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Modals;
using NierReincarnation;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    class TimedQuestFarmDialog : EventQuestFarmDialog
    {
        private readonly List<Term> _timeTable;

        public TimedQuestFarmDialog(NierReinContexts rein, IList<EventQuestData> questList, EventQuestData quest, List<Term> timeTable) :
            base(rein, questList, quest)
        {
            _timeTable = timeTable;
        }

        protected override Task<BattleResult> ExecuteQuest(EventQuestData quest, DataDeck deck)
        {
            if (_timeTable.Any(t => CalculatorDateTime.IsWithinThePeriod(t.Start, t.End)))
                return base.ExecuteQuest(quest, deck);

            Close(DialogResult.Ok);

            return Task.FromResult(new BattleResult(BattleStatus.ForceShutdown));
        }
    }
}