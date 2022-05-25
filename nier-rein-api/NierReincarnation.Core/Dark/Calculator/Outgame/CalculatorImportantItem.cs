using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorImportantItem
    {
        private static EntityMImportantItem GetEntityMImportantItem(int importantItemId)
        {
            var table = DatabaseDefine.Master.EntityMImportantItemTable;
            return table.FindByImportantItemId(importantItemId);
        }

        private static string GetName(int nameImportantItemTextId)
        {
            return string.Format(UserInterfaceTextKey.ImportantItem.kName, nameImportantItemTextId).Localize();
        }

        public static string ImportantItemName(int id)
        {
            var important = GetEntityMImportantItem(id);
            if (important == null)
                return null;

            return GetName(important.NameImportantItemTextId);
        }
    }
}
