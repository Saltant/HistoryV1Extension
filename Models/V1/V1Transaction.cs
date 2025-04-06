using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents the root structure of a blockchain transaction containing full v1 history information.
    /// </summary>
    public class V1Transaction
    {
        [JsonPropertyName("block_num")]
        public long BlockNum { get; set; }

        [JsonPropertyName("block_time")]
        public string BlockTime { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("last_indexed_block")]
        public long LastIndexedBlock { get; set; }

        [JsonPropertyName("last_indexed_block_time")]
        public string LastIndexedBlockTime { get; set; }

        [JsonPropertyName("last_irreversible_block")]
        public long LastIrreversibleBlock { get; set; }

        [JsonPropertyName("query_time_ms")]
        public decimal QueryTimeMs { get; set; }

        [JsonPropertyName("traces")]
        public List<Trace> Traces { get; set; }

        [JsonPropertyName("trx")]
        public Transaction Trx { get; set; }
    }
}
