using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpRinth.Enums;

namespace SharpRinth.Converters
{
    internal class CategoryEnumConverter : JsonConverter<ModCategory>
    {
        public override ModCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "technology" => ModCategory.Technology,
                "adventure" => ModCategory.Adventure,
                "magic" => ModCategory.Magic,
                "utility" => ModCategory.Utility,
                "decoration" => ModCategory.Decoration,
                "library" => ModCategory.Library,
                "cursed" => ModCategory.Cursed,
                "worldgen" => ModCategory.WorldGeneration,
                "storage" => ModCategory.Storage,
                "food" => ModCategory.Food,
                "equipment" => ModCategory.Equipment,
                "misc" => ModCategory.Miscellaneous,
                "fabric" => ModCategory.Fabric,
                "forge" => ModCategory.Forge,
                _ => default
            };
        }

        public override void Write(Utf8JsonWriter writer, ModCategory value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value switch
            {
                ModCategory.Technology => "technology",
                ModCategory.Adventure => "adventure",
                ModCategory.Magic => "magic",
                ModCategory.Utility => "utility",
                ModCategory.Decoration => "decoration",
                ModCategory.Library => "library",
                ModCategory.Cursed => "cursed",
                ModCategory.WorldGeneration => "worldgen",
                ModCategory.Storage => "storage",
                ModCategory.Food => "food",
                ModCategory.Equipment => "equipment",
                ModCategory.Miscellaneous => "misc",
                ModCategory.Fabric => "fabric",
                ModCategory.Forge => "forge",
                _ => null
            });
        }
    }
}
