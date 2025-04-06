using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.Converters.Helpers
{
    /// <summary>
    /// Helper class for deserializing the inner object of TransactionReceiptData.
    /// </summary>
    internal class TransactionReceiptDataInner
    {
        [JsonPropertyName("compression")]
        public string Compression { get; set; }

        [JsonPropertyName("packed_context_free_data")]
        public string PackedContextFreeData { get; set; }

        [JsonPropertyName("packed_trx")]
        public string PackedTrx { get; set; }

        [JsonPropertyName("signatures")]
        public string Signatures { get; set; }
    }
}
