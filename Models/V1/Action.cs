using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents an action performed within a transaction trace.
    /// </summary>
    public class Action
    {
        [JsonPropertyName("account")]
        public string Account { get; set; }

        [JsonPropertyName("authorization")]
        public List<Authorization> Authorization { get; set; }

        [JsonPropertyName("data")]
        public dynamic Data { get; set; }

        [JsonPropertyName("hex_data")]
        public string HexData { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
