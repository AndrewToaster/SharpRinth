using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Enums;

namespace SharpRinth.Converters
{
    internal class SideEnumConverter : JsonConverter<SideDependence>
    {
        public override SideDependence Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "optional" => SideDependence.Optional,
                "required" => SideDependence.Required,
                "unsupported" => SideDependence.Unsupported,
                "unknown" => SideDependence.Unknown,
                _ => SideDependence.Unknown,
            };
        }

        public override void Write(Utf8JsonWriter writer, SideDependence value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value switch
            {
                SideDependence.Optional => "optional",
                SideDependence.Required => "required",
                SideDependence.Unsupported => "unsupported",
                SideDependence.Unknown => "unknown",
                _ => "unknown"
            });
        }
    }
}
