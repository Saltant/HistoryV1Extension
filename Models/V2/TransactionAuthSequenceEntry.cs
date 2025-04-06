using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V2
{
    /// <summary>
    /// Represents an entry in the authorization sequence for a transaction receipt.
    /// </summary>
    public class TransactionAuthSequenceEntry
    {
        /// <summary>
        /// The account name in the authorization sequence.
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }

        /// <summary>
        /// The sequence number for the account as a string.
        /// </summary>
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
