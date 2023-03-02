using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo
{
    static class VersionChecker
    {
        private static readonly string Tag = "Octo/VersionChecker"; // 0x0
        private static readonly string VersionFileName = "v"; // 0x8

        public static bool Check(int version)
        {
            var path = Path.Combine(FileUtil.GetDatabaseRoot(), VersionFileName);

            var localVersion = 0;
            if (File.Exists(path))
            {
                var data = Bytes.ReverseIfNotLittleEndian(FileUtil.ReadAllBytes(path));

                localVersion = BitConverter.ToInt32(data);
            }

            if (localVersion >= version)
                return false;

            Migration(localVersion);

            FileUtil.WriteAllBytes(path, new []{ Bytes.ReverseIfNotLittleEndian(BitConverter.GetBytes(version)) });
            return true;
        }

        private static void Migration(int version)
        {
            if(version>=0x20004)
                return;

            OctoManager.Internal._dataManager.DeleteData();
        }
    }
}
