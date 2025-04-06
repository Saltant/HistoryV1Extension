using Newtonsoft.Json;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents general information about the blockchain node and its current state.
    /// </summary>
    public class BlockchainInfo
    {
        /// <summary>
        /// The version identifier of the server software running the node.
        /// </summary>
        [JsonProperty("server_version")]
        public string ServerVersion { get; set; }

        /// <summary>
        /// The unique identifier of the blockchain (chain ID).
        /// </summary>
        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        /// <summary>
        /// The number of the most recent block in the blockchain (head block).
        /// </summary>
        [JsonProperty("head_block_num")]
        public long HeadBlockNum { get; set; }

        /// <summary>
        /// The number of the last irreversible block in the blockchain.
        /// </summary>
        [JsonProperty("last_irreversible_block_num")]
        public long LastIrreversibleBlockNum { get; set; }

        /// <summary>
        /// The unique identifier of the last irreversible block.
        /// </summary>
        [JsonProperty("last_irreversible_block_id")]
        public string LastIrreversibleBlockId { get; set; }

        /// <summary>
        /// The unique identifier of the most recent block (head block).
        /// </summary>
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }

        /// <summary>
        /// The timestamp of the most recent block, in ISO 8601 format.
        /// </summary>
        [JsonProperty("head_block_time")]
        public string HeadBlockTime { get; set; }

        /// <summary>
        /// The identifier of the producer who created the most recent block.
        /// </summary>
        [JsonProperty("head_block_producer")]
        public string HeadBlockProducer { get; set; }

        /// <summary>
        /// The virtual CPU limit for block processing, in microseconds.
        /// </summary>
        [JsonProperty("virtual_block_cpu_limit")]
        public long VirtualBlockCpuLimit { get; set; }

        /// <summary>
        /// The virtual network limit for block processing, in bytes.
        /// </summary>
        [JsonProperty("virtual_block_net_limit")]
        public long VirtualBlockNetLimit { get; set; }

        /// <summary>
        /// The CPU limit for the current block, in microseconds.
        /// </summary>
        [JsonProperty("block_cpu_limit")]
        public long BlockCpuLimit { get; set; }

        /// <summary>
        /// The network limit for the current block, in bytes.
        /// </summary>
        [JsonProperty("block_net_limit")]
        public long BlockNetLimit { get; set; }

        /// <summary>
        /// The human-readable version string of the server software.
        /// </summary>
        [JsonProperty("server_version_string")]
        public string ServerVersionString { get; set; }

        /// <summary>
        /// The number of the most recent block in the fork database.
        /// </summary>
        [JsonProperty("fork_db_head_block_num")]
        public long ForkDbHeadBlockNum { get; set; }

        /// <summary>
        /// The unique identifier of the most recent block in the fork database.
        /// </summary>
        [JsonProperty("fork_db_head_block_id")]
        public string ForkDbHeadBlockId { get; set; }

        /// <summary>
        /// The full version string of the server, including build details.
        /// </summary>
        [JsonProperty("server_full_version_string")]
        public string ServerFullVersionString { get; set; }

        /// <summary>
        /// The total CPU weight of the blockchain network, as a string to preserve precision.
        /// </summary>
        [JsonProperty("total_cpu_weight")]
        public string TotalCpuWeight { get; set; }

        /// <summary>
        /// The total network weight of the blockchain network, as a string to preserve precision.
        /// </summary>
        [JsonProperty("total_net_weight")]
        public string TotalNetWeight { get; set; }

        /// <summary>
        /// The number of the earliest block available in the node's history.
        /// </summary>
        [JsonProperty("earliest_available_block_num")]
        public long EarliestAvailableBlockNum { get; set; }

        /// <summary>
        /// The timestamp of the last irreversible block, in ISO 8601 format.
        /// </summary>
        [JsonProperty("last_irreversible_block_time")]
        public DateTime LastIrreversibleBlockTime { get; set; }
    }
}
