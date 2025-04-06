using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V2
{
    /// <summary>
    /// Represents the root structure of a blockchain transaction containing full v2 history information.
    /// </summary>
    public class V2Transaction
    {
        /// <summary>
        /// Time taken to execute the query in milliseconds.
        /// </summary>
        [JsonPropertyName("query_time_ms")]
        public decimal QueryTimeMs { get; set; }

        /// <summary>
        /// Indicates whether the transaction was executed successfully.
        /// </summary>
        [JsonPropertyName("executed")]
        public bool Executed { get; set; }

        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        [JsonPropertyName("trx_id")]
        public string TrxId { get; set; }

        /// <summary>
        /// Last irreversible block number.
        /// </summary>
        [JsonPropertyName("lib")]
        public long Lib { get; set; }

        /// <summary>
        /// Indicates whether the last irreversible block was cached.
        /// </summary>
        [JsonPropertyName("cached_lib")]
        public bool CachedLib { get; set; }

        /// <summary>
        /// List of actions performed in the transaction.
        /// </summary>
        [JsonPropertyName("actions")]
        public List<TransactionAction> Actions { get; set; }

        /// <summary>
        /// The last indexed block number.
        /// </summary>
        [JsonPropertyName("last_indexed_block")]
        public long LastIndexedBlock { get; set; }

        /// <summary>
        /// Timestamp of the last indexed block.
        /// </summary>
        [JsonPropertyName("last_indexed_block_time")]
        public string LastIndexedBlockTime { get; set; }
    }
}
