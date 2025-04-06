using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Contains receipt details for a transaction.
    /// </summary>
    public class TransactionReceipt
    {
        [JsonPropertyName("cpu_usage_us")]
        public int CpuUsageUs { get; set; }

        [JsonPropertyName("net_usage_words")]
        public int NetUsageWords { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Transaction receipt data, containing a version number and packed transaction details.
        /// </summary>
        [JsonPropertyName("trx")]
        public TransactionReceiptData Trx { get; set; }
    }
}
