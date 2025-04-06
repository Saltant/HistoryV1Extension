using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents authorization details for an action.
    /// </summary>
    public class Authorization
    {
        [JsonPropertyName("actor")]
        public string Actor { get; set; }

        [JsonPropertyName("permission")]
        public string Permission { get; set; }
    }
}
