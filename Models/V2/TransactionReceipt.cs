using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V2
{
    /// <summary>
    /// Contains receipt information for a transaction action in this query response.
    /// </summary>
    public class TransactionReceipt
    {
        /// <summary>
        /// The account receiving this action.
        /// </summary>
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }

        /// <summary>
        /// Global sequence number of the receipt as a string.
        /// </summary>
        [JsonPropertyName("global_sequence")]
        public string GlobalSequence { get; set; }

        /// <summary>
        /// Receiver sequence number as a string.
        /// </summary>
        [JsonPropertyName("recv_sequence")]
        public string RecvSequence { get; set; }

        /// <summary>
        /// List of authorization sequences for the receipt.
        /// </summary>
        [JsonPropertyName("auth_sequence")]
        public List<TransactionAuthSequenceEntry> AuthSequence { get; set; }
    }
}
