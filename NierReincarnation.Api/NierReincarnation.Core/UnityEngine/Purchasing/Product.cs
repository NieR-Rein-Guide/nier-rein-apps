namespace NierReincarnation.Core.UnityEngine.Purchasing
{
    public class Product
    {
        public ProductDefinition definition { get; set; }
        public ProductMetadata metadata { get; set; }
        public bool availableToPurchase { get; set; }
        public string transactionID { get; set; }
        public string receipt { get; set; }
    }
}
