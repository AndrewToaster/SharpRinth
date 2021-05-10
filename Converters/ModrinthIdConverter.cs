using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Versioning;

namespace SharpRinth.Converters
{
    internal class ModrinthIdConverter : JsonConverter<Identifier>
    {
        public override Identifier Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Identifier(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, Identifier value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Id);
        }
    }
}
