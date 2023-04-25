namespace NierReincarnation.Core.Subsystem.Serval
{
    public static class PermilServal
    {
        public static int multiplyPermil(int number, int permil)
        {
            return permil * number / 1000;
        }

        public static long multiplyPermil(long number, long permil)
        {
            return permil * number / 1000;
        }
    }
}
