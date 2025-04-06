using System.Text.Json.Serialization;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Contains detailed information about a transaction.
    /// </summary>
    public class TransactionDetails
    {
        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; }

        [JsonPropertyName("context_free_actions")]
        public List<object> ContextFreeActions { get; set; }

        [JsonPropertyName("context_free_data")]
        public List<object> ContextFreeData { get; set; }

        [JsonPropertyName("delay_sec")]
        public int DelaySec { get; set; }

        [JsonPropertyName("expiration")]
        public string Expiration { get; set; }

        [JsonPropertyName("max_cpu_usage_ms")]
        public int MaxCpuUsageMs { get; set; }

        [JsonPropertyName("max_net_usage_words")]
        public int MaxNetUsageWords { get; set; }

        [JsonPropertyName("ref_block_num")]
        public int RefBlockNum { get; set; }

        [JsonPropertyName("ref_block_prefix")]
        public long RefBlockPrefix { get; set; }

        [JsonPropertyName("signatures")]
        public List<string> Signatures { get; set; }
    }
}
