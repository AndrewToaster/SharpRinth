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
    /// <summary>
    /// Contains info about a mod search result
    /// </summary>
    public sealed class ModHit
    {
        #region Basic Mod Info

        [JsonPropertyName("title")]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("downloads")]
        public int DownloadCount { get; set; }

        [JsonPropertyName("follows")]
        public int FollowCount { get; set; }

        #endregion Basic Mod Info

        #region URL Links

        [JsonPropertyName("page_url")]
        public string ModrinthUrl { get; set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("author_url")]
        public string AuthorUrl { get; set; }

        #endregion URL Links

        #region Extra Info

        [JsonPropertyName("date_created")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("date_modified")]
        public DateTime LastUpdatedAt { get; set; }

        [JsonPropertyName("latest_version")]
        public IGameVersion LatestVersion { get; set; }

        [JsonPropertyName("server_side")]
        public SideDependence ServerDependence { get; set; }

        [JsonPropertyName("client_side")]
        public SideDependence ClientDependence { get; set; }

        public string License { get; set; }

        /// <summary>
        /// This property is ignored using the <see cref="JsonIgnoreAttribute"/>
        /// </summary>
        [JsonIgnore]
        public string Identifier { get => LocalIdentifier[6..]; set => LocalIdentifier = "local-" + value; }

        public ModCategory[] Categories { get; set; }

        public IGameVersion[] Versions { get; set; }

        [JsonPropertyName("mod_id")]
        public string LocalIdentifier { get; set; }

        #endregion Extra Info
    }
}
