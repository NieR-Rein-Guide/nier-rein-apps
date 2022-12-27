using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImGui.Forms.Modals;
using nier_rein_gui.Resources;
using NierReincarnation.Context.Support;

namespace nier_rein_gui.Support
{
    static class CooldownHelper
    {
        public static async Task<bool> IsOnCooldown()
        {
            var isRunning = CooldownTimer.IsRunning;
            if (isRunning)
                await MessageBox.ShowInformationAsync(LocalizationResources.CooldownTitle, LocalizationResources.CooldownDescription);

            return isRunning;
        }
    }
}
