namespace NierReincarnation.Context.Models.Web
{
    public class Notification
    {
        public InformationType informationType { get; set; }

        public long postscriptDatetime { get; set; }
        public long publishStartDatetime { get; set; }

        public string title { get; set; }
        public string body { get; set; }
    }
}
