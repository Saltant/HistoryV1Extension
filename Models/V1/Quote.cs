using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents a single quote with a pair and value.
    /// </summary>
    public class Quote
    {
        [JsonPropertyName("pair")]
        public string Pair { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}
