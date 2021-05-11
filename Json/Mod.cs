using System;
using System.Text.Json.Serialization;
using SharpRinth.Enums;

namespace SharpRinth.Json
{
    public sealed class Mod
    {
        [JsonPropertyName("id")]
        public Identifier Identifier { get; set; }

        [JsonPropertyName("slug")]
        public string UrlSlug { get; set; }

        [JsonPropertyName("title")]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("body")]
        public string MarkdownBody { get; set; }

        /*
        [Obsolete("Dunno man, Modrinth API says it's obsolete")]
        [JsonPropertyName("body_url")]
        public string MarkdownBodyUrl { get; set; }
        */

        [JsonPropertyName("published")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated")]
        public DateTime LastUpdatedAt { get; set; }

        public ModStatus Status { get; set; }

        public ModLicense License { get; set; }

        [JsonPropertyName("server_side")]
        public SideDependence ServerDependence { get; set; }

        [JsonPropertyName("client_side")]
        public SideDependence ClientDependence { get; set; }

        [JsonPropertyName("downloads")]
        public int DownloadCount { get; set; }

        [JsonPropertyName("follows")]
        public int FollowCount { get; set; }

        public ModCategory[] Categories { get; set; }

        [JsonPropertyName("versions")]
        public Identifier[] Releases { get; set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("source_url")]
        public string SourceCodeUrl { get; set; }

        [JsonPropertyName("issues_url")]
        public string IssuesUrl { get; set; }

        [JsonPropertyName("wiki_url")]
        public string WikiUrl { get; set; }

        [JsonPropertyName("discord_url")]
        public string DiscordUrl { get; set; }

        [JsonPropertyName("donation_urls")]
        public DonationLink[] DontaionLinks { get; set; }
    }
}
