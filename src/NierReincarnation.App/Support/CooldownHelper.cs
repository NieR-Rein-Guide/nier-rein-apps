using ImGui.Forms.Modals;
using NierReincarnation.App.Resources;
using NierReincarnation.Context.Support;
using System.Threading.Tasks;

namespace NierReincarnation.App.Support
{
    internal static class CooldownHelper
    {
        public static async Task<bool> IsOnCooldown()
        {
            bool isRunning = CooldownTimer.IsRunning;
            if (isRunning)
                await MessageBox.ShowInformationAsync(LocalizationResources.CooldownTitle, LocalizationResources.CooldownDescription);

            return isRunning;
        }
    }
}
