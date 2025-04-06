using Newtonsoft.Json;

namespace HistoryV1Extension.Models.V1
{
    /// <summary>
    /// Represents a block in the blockchain containing metadata and a list of transactions.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// The timestamp when the block was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The identifier of the producer who created the block.
        /// </summary>
        [JsonProperty("producer")]
        public string Producer { get; set; }

        /// <summary>
        /// The number of confirmations received for the block.
        /// </summary>
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        /// <summary>
        /// The ID of the previous block in the blockchain.
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// The Merkle root hash of the transactions included in the block.
        /// </summary>
        [JsonProperty("transaction_mroot")]
        public string TransactionMroot { get; set; }

        /// <summary>
        /// The Merkle root hash of the actions included in the block.
        /// </summary>
        [JsonProperty("action_mroot")]
        public string ActionMroot { get; set; }

        /// <summary>
        /// The version number of the producer schedule.
        /// </summary>
        [JsonProperty("schedule_version")]
        public int ScheduleVersion { get; set; }

        /// <summary>
        /// Information about new producers, if any changes occurred, otherwise null.
        /// </summary>
        [JsonProperty("new_producers")]
        public object NewProducers { get; set; }

        /// <summary>
        /// The cryptographic signature of the producer validating the block.
        /// </summary>
        [JsonProperty("producer_signature")]
        public string ProducerSignature { get; set; }

        /// <summary>
        /// The list of transactions included in the block.
        /// </summary>
        [JsonProperty("transactions")]
        public List<BlockTransaction> Transactions { get; set; }

        /// <summary>
        /// The unique identifier of the block.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The sequential number of the block in the blockchain.
        /// </summary>
        [JsonProperty("block_num")]
        public long BlockNum { get; set; }

        /// <summary>
        /// The prefix of the reference block used for validation.
        /// </summary>
        [JsonProperty("ref_block_prefix")]
        public long RefBlockPrefix { get; set; }
    }
}
