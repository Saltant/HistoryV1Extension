using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Contains the data payload for an action.
    /// </summary>
    public class ActionData
    {
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("quotes")]
        public List<Quote> Quotes { get; set; }
    }
}
