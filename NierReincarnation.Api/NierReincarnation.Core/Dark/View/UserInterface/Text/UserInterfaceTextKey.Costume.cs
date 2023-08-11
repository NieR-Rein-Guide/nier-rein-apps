namespace NierReincarnation.Core.Dark.View.UserInterface.Text
{
    public static partial class UserInterfaceTextKey
    {
        public static class Costume
        {
            private const string kCostumePrefix = "costume.";
            private const string kCostumeReplacePrefix = "replace.";
            public static readonly string kName = kCostumePrefix + CommonKeyParts.kName;
            public static readonly string kNameReplace = kCostumePrefix + "name." + kCostumeReplacePrefix + Common.kOneValueFormat;
            public static readonly string kDescription = kCostumePrefix + "description." + Common.kOneValueFormat;
            public static readonly string kDescriptionReplace = kCostumePrefix + "description." + kCostumeReplacePrefix + Common.kOneValueFormat;
            public static readonly string kEmblemName = kCostumePrefix + "emblem." + CommonKeyParts.kName;
        }
    }
}
