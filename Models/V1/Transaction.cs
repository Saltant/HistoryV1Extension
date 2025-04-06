using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents a transaction.
    /// </summary>
    public class Transaction
    {
        [JsonPropertyName("receipt")]
        public TransactionReceipt Receipt { get; set; }

        [JsonPropertyName("trx")]
        public TransactionDetails Trx { get; set; }
    }
}
