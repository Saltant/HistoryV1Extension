using HistoryV1Extension.Models.Converters;
using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents the detailed transaction data within a receipt.
    /// </summary>
    [JsonConverter(typeof(TransactionReceiptDataConverter))]
    public class TransactionReceiptData
    {
        /// <summary>
        /// Version or type identifier of the transaction.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }

        /// <summary>
        /// Compression type used for the transaction data.
        /// </summary>
        [JsonPropertyName("compression")]
        public string Compression { get; set; }

        /// <summary>
        /// Packed context-free data in hexadecimal format.
        /// </summary>
        [JsonPropertyName("packed_context_free_data")]
        public string PackedContextFreeData { get; set; }

        /// <summary>
        /// Packed transaction data in hexadecimal format.
        /// </summary>
        [JsonPropertyName("packed_trx")]
        public string PackedTrx { get; set; }

        /// <summary>
        /// List of signatures for the transaction.
        /// </summary>
        [JsonPropertyName("signatures")]
        public string Signatures { get; set; }
    }
}
