using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents an entry in the authorization sequence with an actor and sequence number.
    /// </summary>
    public class AuthSequenceEntry
    {
        /// <summary>
        /// The actor name.
        /// </summary>
        [JsonPropertyName("0")]
        public string Actor { get; set; }

        /// <summary>
        /// The sequence number.
        /// </summary>
        [JsonPropertyName("1")]
        public long Sequence { get; set; }
    }
}
