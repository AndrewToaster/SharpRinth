using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Enums;

namespace SharpRinth.Converters
{
    internal class StatusEnumConverter : JsonConverter<ModStatus>
    {
        public override ModStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "approved" => ModStatus.Approved,
                "draft" => ModStatus.Draft,
                "unlisted" => ModStatus.Unlisted,
                "processing" => ModStatus.Processing,
                "rejected" => ModStatus.Rejected,
                "unknown" => ModStatus.Unknown,
                _ => ModStatus.Unknown,
            };
        }

        public override void Write(Utf8JsonWriter writer, ModStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value switch
            {
                ModStatus.Approved => "approved",
                ModStatus.Draft => "draft",
                ModStatus.Unlisted => "unlisted",
                ModStatus.Processing => "processing",
                ModStatus.Rejected => "rejected",
                ModStatus.Unknown => "unknown",
                _ => "unknown"
            });
        }
    }
}
