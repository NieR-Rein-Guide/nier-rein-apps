namespace NierReincarnation.Context.Models
{
    public struct SubjugationGrade
    {
        public Grade Grade { get; set; }
        public int Rank { get; set; }

        public int GetOrder()
        {
            return (int)Grade * 10 + Rank - 1;
        }

        public override string ToString()
        {
            return $"{Grade}{Rank}";
        }
    }

    public enum Grade
    {
        G,
        F,
        E,
        D,
        C,
        B,
        A,
        S,
        SS,
        SSS
    }
}
