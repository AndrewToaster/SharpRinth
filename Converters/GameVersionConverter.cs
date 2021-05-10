using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Versioning;

namespace SharpRinth.Converters
{
    internal class GameVersionConverter : JsonConverter<IGameVersion>
    {
        public override IGameVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new PlainVersion(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, IGameVersion value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.VersionString);
        }
    }
}
