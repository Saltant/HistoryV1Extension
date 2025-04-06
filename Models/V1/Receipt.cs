using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Contains receipt information for a transaction trace.
    /// </summary>
    public class Receipt
    {
        [JsonPropertyName("abi_sequence")]
        public int AbiSequence { get; set; }

        [JsonPropertyName("act_digest")]
        public string ActDigest { get; set; }

        /// <summary>
        /// List of authorization sequences, each containing an actor (string) and sequence number (long).
        /// </summary>
        [JsonPropertyName("auth_sequence")]
        public List<AuthSequenceEntry> AuthSequence { get; set; }

        [JsonPropertyName("code_sequence")]
        public int CodeSequence { get; set; }

        [JsonPropertyName("global_sequence")]
        public long GlobalSequence { get; set; }

        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }

        [JsonPropertyName("recv_sequence")]
        public long RecvSequence { get; set; }
    }
}
