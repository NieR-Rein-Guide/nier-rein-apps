namespace NierReincarnation.Core.Dark.View.UserInterface.Text
{
    public static partial class UserInterfaceTextKey
    {
        public static class Costume
        {
            private const string kCostumePrefix = "costume."; // 0x0
            private const string kCostumeReplacePrefix = "replace."; // 0x8
            public static readonly string kName = kCostumePrefix + CommonKeyParts.kName; // 0x10
            public static readonly string kNameReplace = kCostumePrefix + "name." + kCostumeReplacePrefix + Common.kOneValueFormat; // 0x18
            public static readonly string kDescription = kCostumePrefix + "description." + Common.kOneValueFormat; // 0x20
            public static readonly string kDescriptionReplace = kCostumePrefix + "description." + kCostumeReplacePrefix + Common.kOneValueFormat; // 0x28
            public static readonly string kEmblemName = kCostumePrefix + "emblem." + CommonKeyParts.kName; // 0x30
        }
    }
}
