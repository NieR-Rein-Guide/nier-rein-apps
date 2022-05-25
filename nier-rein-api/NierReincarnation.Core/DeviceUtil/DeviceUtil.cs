namespace NierReincarnation.Core.DeviceUtil
{
    // DeviceUtil.DeviceUtil
    static class DeviceUtil
    {
        private static string _mdcs;

        public static bool GetIjb()
        {
            return false;
        }

        public static bool GetHig()
        {
            return false;
        }

        public static string GetAcs()
        {
            // using var javaObject = new UnityEngine.AndroidJavaObject("com.nekolaboratory.Seeker.Seeker", Array.Empty<object>());
            // return javaObject.Call("sType");

            // TODO: Get static value
            return string.Empty;
        }

        public static bool GetPer()
        {
            // using var javaObject = new UnityEngine.AndroidJavaObject("com.nekolaboratory.Seek.Seeker", Array.Empty<object>());
            // return javaObject.Call("pType");

            return false;
        }

        public static bool GetImu()
        {
            // using var javaObject = new UnityEngine.AndroidJavaObject("com.nekolaboratory.Seeker.Seeker", Array.Empty<object>());
            // return javaObject.Call("eType");

            return false;
        }

        public static bool GetIr()
        {
            // using var javaObject = new UnityEngine.AndroidJavaObject("com.nekolaboratory.Seeker.Seeker", Array.Empty<object>());
            // return javaObject.Call("rType");

            return false;
        }

        public static bool GetIda()
        {
            // using var javaObject = new UnityEngine.AndroidJavaObject("com.nekolaboratory.Seeker.Seeker", Array.Empty<object>());
            // return javaObject.Call("dType");

            return false;
        }

        public static string[] GetMsl()
        {
            return new string[0];

            // Unreachable code in assembly?
            //var delimiter = ",";
        }

        public static string GetIcs()
        {
            return string.Empty;
        }

        public static void SetMdcs(string version, string checksum)
        {
            _mdcs = $"{{\"v\": \"{version}\", \"cs\": \"{checksum}\"}}";
        }
    }
}
