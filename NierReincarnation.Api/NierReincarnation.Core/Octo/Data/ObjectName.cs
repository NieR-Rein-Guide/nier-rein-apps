using System.Text;

namespace NierReincarnation.Core.Octo.Data
{
    public struct ObjectName
    {
        // Fields
        private static readonly Encoding ascii = Encoding.ASCII;

        private byte b0;
        private byte b1;
        private byte b2;
        private byte b3;
        private byte b4;
        private byte b5;

        // Methods

        // RVA: 0x3302C9C Offset: 0x3302C9C VA: 0x3302C9C
        public void Set(string name)
        {
            if (name == null || name.Length != 6)
                return;

            var data = ascii.GetBytes(name);

            b0 = data[0];
            b1 = data[1];
            b2 = data[2];
            b3 = data[3];
            b4 = data[4];
            b5 = data[5];
        }

        // RVA: 0x32FC6B4 Offset: 0x32FC6B4 VA: 0x32FC6B4 Slot: 3
        public override string ToString()
        {
            return ascii.GetString(new[] {b0, b1, b2, b3, b4, b5});
        }

        // RVA: 0x330284C Offset: 0x330284C VA: 0x330284C
        public string ToHexString()
        {
            return $"{b0:X}{b1:X}{b1:X}{b2:X}{b3:X}{b4:X}{b5:X}";
        }
    }
}
