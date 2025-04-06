using Newtonsoft.Json;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents the detailed data of a transaction, including its ID, signatures, and inner transaction object.
    /// </summary>
    public class Trx
    {
        /// <summary>
        /// The unique identifier of the transaction.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The list of cryptographic signatures authorizing the transaction.
        /// </summary>
        public List<string> Signatures { get; set; }

        /// <summary>
        /// The compression method used for the transaction data (e.g., "none").
        /// </summary>
        public string Compression { get; set; }

        /// <summary>
        /// The packed representation of context-free data, if any.
        /// </summary>
        [JsonProperty("packed_context_free_data")]
        public string PackedContextFreeData { get; set; }

        /// <summary>
        /// The list of context-free data associated with the transaction.
        /// </summary>
        [JsonProperty("context_free_data")]
        public List<object> ContextFreeData { get; set; }

        /// <summary>
        /// The packed hexadecimal representation of the transaction.
        /// </summary>
        [JsonProperty("packed_trx")]
        public string PackedTrx { get; set; }

        /// <summary>
        /// The inner transaction object containing expiration and actions.
        /// </summary>
        public InnerTransaction Transaction { get; set; }
    }
}
