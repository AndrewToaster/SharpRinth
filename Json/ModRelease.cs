using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SharpRinth.Enums;
using SharpRinth.Versioning;

namespace SharpRinth.Json
{
    public sealed class ModRelease
    {
        [JsonPropertyName("id")]
        public Identifier VersionId { get; set; }

        [JsonPropertyName("mod_id")]
        public Identifier ModId { get; set; }

        [JsonPropertyName("author_id")]
        public Identifier AuthorId { get; set; }

        public bool Featured { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("version_number")]
        public string VersionString { get; set; }

        public string Changelog { get; set; }

        [JsonPropertyName("changelog_url")]
        public string ChangelogUrl { get; set; }

        [JsonPropertyName("date_published")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("downloads")]
        public int DownloadCount { get; set; }

        [JsonPropertyName("version_type")]
        public ReleaseType ReleaseType { get; set; }

        public ReleaseFile[] Files { get; set; }

        public Identifier[] Dependencies { get; set; }

        [JsonPropertyName("game_versions")]
        public IGameVersion[] GameVersions { get; set; }

        [JsonPropertyName("loaders")]
        public string[] CompatibleModLoaders { get; set; }
    }
}
