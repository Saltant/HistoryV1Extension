using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents a single trace of a transaction.
    /// </summary>
    public class Trace
    {
        [JsonPropertyName("account_ram_deltas")]
        public List<object> AccountRamDeltas { get; set; }

        [JsonPropertyName("act")]
        public Action Act { get; set; }

        [JsonPropertyName("action_ordinal")]
        public int ActionOrdinal { get; set; }

        [JsonPropertyName("block_num")]
        public long BlockNum { get; set; }

        [JsonPropertyName("block_time")]
        public string BlockTime { get; set; }

        [JsonPropertyName("closest_unnotified_ancestor_action_ordinal")]
        public int ClosestUnnotifiedAncestorActionOrdinal { get; set; }

        [JsonPropertyName("context_free")]
        public bool ContextFree { get; set; }

        [JsonPropertyName("creator_action_ordinal")]
        public int CreatorActionOrdinal { get; set; }

        [JsonPropertyName("elapsed")]
        public long Elapsed { get; set; }

        [JsonPropertyName("producer_block_id")]
        public string ProducerBlockId { get; set; }

        [JsonPropertyName("receipt")]
        public Receipt Receipt { get; set; }

        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }

        [JsonPropertyName("trx_id")]
        public string TrxId { get; set; }
    }
}
