using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models
{
    /// <summary>
    /// Represents transaction request
    /// </summary>
    public class GetTransactionRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("block_num_hint")]
        public int BlockNumberHint { get; set; }
    }
}
