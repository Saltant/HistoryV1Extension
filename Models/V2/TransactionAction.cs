using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V2
{
    /// <summary>
    /// Represents detailed information about an action within a transaction.
    /// </summary>
    public class TransactionAction
    {
        /// <summary>
        /// The ordinal number of the action within the transaction.
        /// </summary>
        [JsonPropertyName("action_ordinal")]
        public int ActionOrdinal { get; set; }

        /// <summary>
        /// The ordinal of the action that created this action.
        /// </summary>
        [JsonPropertyName("creator_action_ordinal")]
        public int CreatorActionOrdinal { get; set; }

        /// <summary>
        /// The action performed in this transaction.
        /// </summary>
        [JsonPropertyName("act")]
        public V1.Action Act { get; set; }

        /// <summary>
        /// Deltas
        /// </summary>
        [JsonPropertyName("account_ram_deltas")]
        public List<dynamic> AccountRamDeltas { get; set; }

        /// <summary>
        /// Timestamp of the action (with @ prefix in JSON).
        /// </summary>
        [JsonPropertyName("@timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The block number where this action resides.
        /// </summary>
        [JsonPropertyName("block_num")]
        public long BlockNum { get; set; }

        /// <summary>
        /// Unique identifier of the block.
        /// </summary>
        [JsonPropertyName("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        /// The producer of the block.
        /// </summary>
        [JsonPropertyName("producer")]
        public string Producer { get; set; }

        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        [JsonPropertyName("trx_id")]
        public string TrxId { get; set; }

        /// <summary>
        /// Global sequence number of the action.
        /// </summary>
        [JsonPropertyName("global_sequence")]
        public long GlobalSequence { get; set; }

        /// <summary>
        /// CPU usage in microseconds for this action.
        /// </summary>
        [JsonPropertyName("cpu_usage_us")]
        public int CpuUsageUs { get; set; }

        /// <summary>
        /// Network usage in words for this action.
        /// </summary>
        [JsonPropertyName("net_usage_words")]
        public int NetUsageWords { get; set; }

        /// <summary>
        /// List of signatures for the action.
        /// </summary>
        [JsonPropertyName("signatures")]
        public List<string> Signatures { get; set; }

        /// <summary>
        /// Sequence number of the code.
        /// </summary>
        [JsonPropertyName("code_sequence")]
        public int CodeSequence { get; set; }

        /// <summary>
        /// Sequence number of the ABI.
        /// </summary>
        [JsonPropertyName("abi_sequence")]
        public int AbiSequence { get; set; }

        /// <summary>
        /// Digest of the action.
        /// </summary>
        [JsonPropertyName("act_digest")]
        public string ActDigest { get; set; }

        /// <summary>
        /// List of receipts for this action.
        /// </summary>
        [JsonPropertyName("receipts")]
        public List<TransactionReceipt> Receipts { get; set; }

        /// <summary>
        /// Timestamp of the action (duplicate of @timestamp).
        /// </summary>
        [JsonPropertyName("timestamp")]
        public string TimestampDuplicate { get; set; }
    }
}
