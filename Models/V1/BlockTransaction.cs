using Newtonsoft.Json;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents a transaction within a block, detailing its execution status and resource usage.
    /// </summary>
    public class BlockTransaction
    {
        /// <summary>
        /// The execution status of the transaction (e.g., "executed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The CPU usage of the transaction in microseconds.
        /// </summary>
        [JsonProperty("cpu_usage_us")]
        public int CpuUsageUs { get; set; }

        /// <summary>
        /// The network usage of the transaction measured in words.
        /// </summary>
        [JsonProperty("net_usage_words")]
        public int NetUsageWords { get; set; }

        /// <summary>
        /// The detailed transaction data, including signatures and actions.
        /// </summary>
        public Trx Trx { get; set; }
    }
}
