using System.Text.Json.Serialization;
using System.Text.Json;
using HistoryV1Extension.Models.Converters.Helpers;
using System.Text.Json.Nodes;
using HistoryV1Extension.Models.V1;

namespace HistoryV1Extension.Models.Converters
{
    public class TransactionReceiptDataConverter : JsonConverter<TransactionReceiptData>
    {
        public override TransactionReceiptData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            reader.Read(); // Move to first element (version)
            int version = reader.GetInt32();

            reader.Read(); // Move to object

            var data = JsonSerializer.Deserialize<TransactionReceiptDataInner>(ref reader, options);

            reader.Read(); // Move past end of array

            return new TransactionReceiptData
            {
                Version = version,
                Compression = data.Compression,
                PackedContextFreeData = data.PackedContextFreeData,
                PackedTrx = data.PackedTrx,
                Signatures = data.Signatures
            };
        }

        public override void Write(Utf8JsonWriter writer, TransactionReceiptData value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Version);
            JsonSerializer.Serialize(writer, new TransactionReceiptDataInner
            {
                Compression = value.Compression,
                PackedContextFreeData = value.PackedContextFreeData,
                PackedTrx = value.PackedTrx,
                Signatures = value.Signatures
            }, options);
            writer.WriteEndArray();
        }
    }
}
