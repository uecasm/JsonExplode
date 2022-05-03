using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonExplode
{
    public class ExplodingData
    {
        public string? Value { get; set; }
    }

    public class ExplodingConverter : JsonConverter<ExplodingData>
    {
        public override ExplodingData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

            using var jsonDocument = JsonDocument.ParseValue(ref reader);

            return (ExplodingData?) JsonSerializer.Deserialize(jsonDocument.RootElement.GetRawText(), typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, ExplodingData value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
