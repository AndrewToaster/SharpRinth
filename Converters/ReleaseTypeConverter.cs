using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Enums;
using SharpRinth.Versioning;

namespace SharpRinth.Converters
{
    internal class ReleaseTypeConverter : JsonConverter<ReleaseType>
    {
        public override ReleaseType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "release" => ReleaseType.Release,
                "beta" => ReleaseType.Beta,
                "alpha" => ReleaseType.Alpha,
                _ => ReleaseType.Alpha,
            };
        }

        public override void Write(Utf8JsonWriter writer, ReleaseType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value switch
            {
                ReleaseType.Release => "release",
                ReleaseType.Beta => "beta",
                ReleaseType.Alpha => "alpha",
                _ => null
            });
        }
    }
}
