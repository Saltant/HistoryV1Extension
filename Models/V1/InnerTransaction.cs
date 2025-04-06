using Newtonsoft.Json;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents the inner transaction object within a Trx, specifying execution parameters and actions.
    /// </summary>
    public class InnerTransaction
    {
        /// <summary>
        /// The expiration timestamp of the transaction, in ISO 8601 format.
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// The reference block number used for transaction validation.
        /// </summary>
        [JsonProperty("ref_block_num")]
        public int RefBlockNum { get; set; }

        /// <summary>
        /// The reference block prefix used for transaction validation.
        /// </summary>
        [JsonProperty("ref_block_prefix")]
        public long RefBlockPrefix { get; set; }

        /// <summary>
        /// The maximum network usage allowed for the transaction in words.
        /// </summary>
        [JsonProperty("max_net_usage_words")]
        public int MaxNetUsageWords { get; set; }

        /// <summary>
        /// The maximum CPU usage allowed for the transaction in milliseconds.
        /// </summary>
        [JsonProperty("max_cpu_usage_ms")]
        public int MaxCpuUsageMs { get; set; }

        /// <summary>
        /// The delay in seconds before the transaction is executed.
        /// </summary>
        [JsonProperty("delay_sec")]
        public int DelaySec { get; set; }

        /// <summary>
        /// The list of context-free actions associated with the transaction.
        /// </summary>
        [JsonProperty("context_free_actions")]
        public List<Action> ContextFreeActions { get; set; }

        /// <summary>
        /// The list of actions to be executed within the transaction.
        /// </summary>
        public List<Action> Actions { get; set; }
    }
}
