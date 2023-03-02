using System;

namespace NierReincarnation.Core.Octo.Util
{
    public struct MD5Value
    {
        private byte b0; // 0x0
        private byte b1; // 0x1
        private byte b2; // 0x2
        private byte b3; // 0x3
        private byte b4; // 0x4
        private byte b5; // 0x5
        private byte b6; // 0x6
        private byte b7; // 0x7
        private byte b8; // 0x8
        private byte b9; // 0x9
        private byte b10; // 0xA
        private byte b11; // 0xB
        private byte b12; // 0xC
        private byte b13; // 0xD
        private byte b14; // 0xE
        private byte b15; // 0xF

        // Methods

        // RVA: 0x3EC9218 Offset: 0x3EC9218 VA: 0x3EC9218
        public MD5Value(string md5)
        {
            b0 = 0;
            b1 = 0;
            b2 = 0;
            b3 = 0;
            b4 = 0;
            b5 = 0;
            b6 = 0;
            b7 = 0;
            b8 = 0;
            b9 = 0;
            b10 = 0;
            b11 = 0;
            b12 = 0;
            b13 = 0;
            b14 = 0;
            b15 = 0;

            Set(md5);
        }

        // RVA: 0x3EC9DA8 Offset: 0x3EC9DA8 VA: 0x3EC9DA8
        public bool Equals(MD5Value md5)
        {
            return b0 == md5.b0 &&
                   b1 == md5.b1 &&
                   b2 == md5.b2 &&
                   b3 == md5.b3 &&
                   b4 == md5.b4 &&
                   b5 == md5.b5 &&
                   b6 == md5.b6 &&
                   b7 == md5.b7 &&
                   b8 == md5.b8 &&
                   b9 == md5.b9 &&
                   b10 == md5.b10 &&
                   b11 == md5.b11 &&
                   b12 == md5.b12 &&
                   b13 == md5.b13 &&
                   b14 == md5.b14 &&
                   b15 == md5.b15;
        }

        // RVA: 0x3EC9220 Offset: 0x3EC9220 VA: 0x3EC9220
        public void Set(string md5)
        {
            var hex = Convert.FromHexString(md5);

            b0 = hex[0];
            b1 = hex[1];
            b2 = hex[2];
            b3 = hex[3];
            b4 = hex[4];
            b5 = hex[5];
            b6 = hex[6];
            b7 = hex[7];
            b8 = hex[8];
            b9 = hex[9];
            b10 = hex[10];
            b11 = hex[11];
            b12 = hex[12];
            b13 = hex[13];
            b14 = hex[14];
            b15 = hex[15];
        }
    }
}
